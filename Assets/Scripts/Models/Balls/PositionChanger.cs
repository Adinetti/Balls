using UnityEngine;
using BallsGame.GameCamera;

namespace BallsGame { 
	public class PositionChanger {
        private const float OFFSET = 0.1f;

        private Vector3 _defaultPosition;
        private ICamera _camera;
        private float _offsetZ;

        public PositionChanger(Vector3 defaultPosition, ICamera camera) {
            _defaultPosition = defaultPosition;
            _camera = camera;
        }

        public void Restart() {
            _offsetZ = 0;
        }

        public Vector3 CreateBallPosition(float ballSize) {
            var position = _defaultPosition;
            var offset = 0.5f * (_camera.WidthScreenToWorldSpace - ballSize);
            position.x += Random.Range(-offset, offset);
            position.z += _offsetZ;
            _offsetZ += OFFSET;
            return position;
        }
    }
}


