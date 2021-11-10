using UnityEngine;

namespace BallsGame.Models.Balls.Movers { 
	public interface IBallMover {
		/// <summary>
		/// Return next position for ball
		/// </summary>
		Vector3 GetNextPostion(IBall ball, float deltaTime);
	}
}


