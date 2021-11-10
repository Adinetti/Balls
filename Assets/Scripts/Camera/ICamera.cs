using UnityEngine;

namespace BallsGame.GameCamera { 
	public interface ICamera {
		/// <summary>
		/// Return world projection for screen point in (0.5, 1) by screenSpace
		/// </summary>
		Vector3 CenterTopPoint { get; }

		/// <summary>
		/// Return world space projection of screen width   
		/// </summary>
		float WidthScreenToWorldSpace { get; }
	}
}


