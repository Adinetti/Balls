namespace BallsGame.Models.Balls {
    [System.Serializable]
	public class BallSetup {
		public SpeedRange speed;
		public DamageRange damage;
		public SizeRange size;
		public PriceRange price;
	}

	[System.Serializable]
	public class SpeedRange {
		public float min = 1;
		public float max = 2;
		public float accleration = 0.5f;
	}

	[System.Serializable]
	public class DamageRange {
		public int min = 1;
		public int max = 2;
	}

	[System.Serializable]
	public class SizeRange {
		public float min = 1;
		public float max = 2;
	}

	[System.Serializable]
	public class PriceRange {
		public int min = 1;
		public int max = 2;
	}
}


