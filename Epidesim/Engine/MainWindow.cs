﻿using System;
using System.IO;
using Epidesim.Engine.Drawing;
using Epidesim.Simulation;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Epidesim.Engine.Drawing.Types;
using Epidesim.Engine.Drawing.Types.Shaders;
using System.Diagnostics;
using System.Drawing;
using Epidesim.Simulation.Polygon;

namespace Epidesim.Engine
{
	class MainWindow : GameWindow
	{
		#region Fields

		private PolygonSimulation SimulationToRun;
		private ISimulationRenderer<PolygonSimulation> SimulationRenderer;
		
		public Color4 BackgroundColor { get; set; }

		private static MainWindow _instance;
		public static MainWindow Get()
		{
			if (_instance == null)
			{
				_instance = new MainWindow(1000, 700, "hello world");
			}
			return _instance;
		}

		#endregion

		#region Constructors

		private MainWindow(int width, int height, string title)
			: base(width, height, GraphicsMode.Default, title)
		{
			SimulationRenderer = new PolygonSimulationRenderer();
			SimulationToRun = new PolygonSimulation(width, height);
			BackgroundColor = Color.MidnightBlue;
		}

		~MainWindow()
		{
		}

		#endregion

		#region Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// depth doesn't seem to work with blending
			//GL.Enable(EnableCap.DepthTest);

			GL.Enable(EnableCap.Blend);
			GL.Enable(EnableCap.AlphaTest);
			GL.Enable(EnableCap.Texture2D);

			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

			SimulationToRun.Start();
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			Input.Refresh();

			SimulationToRun.Update(e.Time);

			if (Input.IsKeyDown(Key.Escape))
			{
				base.Exit();
			}

			base.OnUpdateFrame(e);
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			GL.ClearColor(BackgroundColor);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			SimulationRenderer.Render(SimulationToRun);

			base.Context.SwapBuffers();
			base.OnRenderFrame(e);
		}

		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);
			SimulationToRun.ScreenWidth = Width;
			SimulationToRun.ScreenHeight = Height;
			SimulationToRun.CameraRectangle = 
				Drawing.Types.Rectangle.FromCenterAndSize(SimulationToRun.CameraRectangle.Center, new Vector2(Width, Height));
			base.OnResize(e);
		}

		protected override void OnUnload(EventArgs e)
		{
		}

		#endregion
	}
}
