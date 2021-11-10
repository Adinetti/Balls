using BallsGame.Models.Balls;

namespace BallsGame.Models.Players { 
	public class PlayerScore {
		public int Last { get; private set; }
		public int Max { get; private set; }

        public PlayerScore(IPlayer player) {
			player.OnKillBall += Add;
        }

		public void ResetLastScore() {
			Last = 0;
        }

		private void Add(IBall ball) {
			Last += ball.Price;
			if (Last > Max) {
				Max = Last;
            }
        }
	}
}


