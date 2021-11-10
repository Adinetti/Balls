using BallsGame.Views;
using BallsGame.Models.Balls;

namespace BallsGame.UI { 
	public interface IUserInterface  {
		void Pause();
		void Restart();
		void KillBall(IBall ball);
	}
}


