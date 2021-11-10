using UnityEngine;

namespace BallsGame.Models.Balls.Movers {
    public class LinearMover : IBallMover {
        public Vector3 GetNextPostion(IBall ball, float deltaTime) {
            return ball.Position - Vector3.up * ball.Speed * deltaTime;
        }
    }
}


