using UnityEngine;

namespace BallsGame.Models.Balls {
	public interface IDeadZone {
		bool IsBallInside(IBall ball);
	}
}


