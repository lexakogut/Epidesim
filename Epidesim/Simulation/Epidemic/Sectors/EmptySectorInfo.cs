﻿using Epidesim.Simulation.Epidemic.Distributions;

namespace Epidesim.Simulation.Epidemic.Sectors
{
	class EmptySectorInfo : SectorInfo
	{
		public override string Name => "Empty";

		public override ValueDistribution SquareMetersPerCreature => new GaussianDistribution()
		{
			Mean = 20,
			Deviation = 10,
			Min = 5
		};

		public override ValueDistribution IdleTime => new GaussianDistribution()
		{
			Mean = 20,
			Deviation = 20,
			Min = 5
		};

		public override ValueDistribution PositionDistribution => new FixedDistribution()
		{
			Min = -1,
			Max = 1
		};


		public override float AllowHealthyCreatures => 1f;
		public override float AllowIllCreatures => 0.25f;
		public override float AllowImmuneCreatures => 1f;
	}
}
