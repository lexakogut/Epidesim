﻿namespace Epidesim.Simulation.Epidemic
{
	abstract class SectorInfo
	{
		public string Name { get; protected set; }
		public ValueDistribution IdleTimeDistribution { get; protected set; }
		public ValueDistribution PositionDistribution { get; protected set; }

		public float SquareMetersPerCreature { get; protected set; }
		public float PreferenceHealthyCreatures { get; protected set; }
		public float PreferenceIllCreatures { get; protected set; }
		public float PreferenceImmuneCreatures { get; protected set; }
		public float RecoveryMultiplier { get; protected set; }
		public float DeathRateMultiplier { get; protected set; }
		public float SpreadMultiplier { get; protected set; }

		public bool CanBeQuarantined { get; set; }
	}
}
