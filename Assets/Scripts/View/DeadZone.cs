using BallsGame.GameCamera;
using BallsGame.Models.Balls;
using UnityEngine;

namespace BallsGame.Views {
    public class DeadZone : MonoBehaviour, IDeadZone {
        public bool IsBallInside(IBall ball) {
            var topPoint = ball.Position.y + .5 * ball.Size;
            return transform.position.y > topPoint;
        }

        private void Start() {
            ICamera camera = transform.root.GetComponentInChildren<ICamera>();
            var position = camera.Position - (camera.CenterTopPoint - camera.Position);
            transform.position = position;
        }
    }
}


