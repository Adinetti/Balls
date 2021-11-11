using UnityEngine;

namespace BallsGame.GameCamera {
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour, ICamera {
        private float _widthScreenToWorldSpace;
        private Vector3 _centerTopPoint;
        private Vector2Int resolution;
        private Camera _camera;

        public Vector3 Position => _camera.transform.position;

        public Vector3 CenterTopPoint {
            get {
                if (resolution.x == Screen.width && resolution.y == Screen.height) {
                    return _centerTopPoint;
                }
                _centerTopPoint = CalculateCenterPoint();
                return _centerTopPoint;
            }
        }

        public float WidthScreenToWorldSpace {
            get {
                if (resolution.x == Screen.width && resolution.y == Screen.height) {
                    return _widthScreenToWorldSpace;
                }
                _widthScreenToWorldSpace = CalculateWidth();
                return _widthScreenToWorldSpace;
            }
        }

        private void Awake() {
            _camera = GetComponent<Camera>();
            resolution = new Vector2Int(Screen.width, Screen.height);
            _widthScreenToWorldSpace = CalculateWidth();
            _centerTopPoint = CalculateCenterPoint();
        }

        private float CalculateWidth() {
            var screenSpaceRightPosition = new Vector3(resolution.x, resolution.y, 1);
            var screenSpaceLeftPosition = new Vector3(0, resolution.y, 1);
            var rightPoint = _camera.ScreenToWorldPoint(screenSpaceRightPosition).x;
            var leftPoint = _camera.ScreenToWorldPoint(screenSpaceLeftPosition).x;
            return  rightPoint - leftPoint;
        }

        private Vector3 CalculateCenterPoint() {
            var screenSpacePosition = new Vector3(resolution.x / 2f, resolution.y, 1);
            return _camera.ScreenToWorldPoint(screenSpacePosition);
        }
    }
}


