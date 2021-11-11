using UnityEngine;
using BallsGame.Models.Balls;
using BallsGame.GameCamera;
using BallsGame.Models.Balls.Movers;
using System.Collections.Generic;

namespace BallsGame.Views {
    public class BallStorage : MonoBehaviour {
        private GameStateManager _stateManager;
        [SerializeField] private BallSetup _ballSetup;
        [SerializeField] private float _creationDelay = 1;
        private float _timer;
        private ICamera _camera;
        private Ball _ballPrefab;
        private List<Ball> _ballBuffer;
        private IDeadZone _deadZone;
        private BallSetupCreator _setupCreator;
        private StartPositionCreator _positionChanger;

        private void Awake() {
            _stateManager = transform.root.GetComponent<GameStateManager>();
            _camera = _stateManager.GetComponentInChildren<ICamera>();
            _ballPrefab = GetComponentInChildren<Ball>();
            _deadZone = GetComponentInChildren<IDeadZone>();
            _ballBuffer = new List<Ball>();
            _setupCreator = new BallSetupCreator(_ballSetup);
        }

        private void Start() {
            ChangePosition();
            Restart();
        }

        private void OnEnable() {
            _stateManager.OnRestart += Restart;
            _stateManager.OnRun += StartBalls;
        }

        private void OnDisable() {
            _stateManager.OnRestart -= Restart;
            _stateManager.OnRun -= StartBalls;
        }

        private void ChangePosition() {
            var position = _camera.CenterTopPoint;
            position.y += _ballSetup.size.max;
            transform.position = position;
            _positionChanger = new StartPositionCreator(transform.position, _camera);
        }

        private void Restart() {
            _timer = _creationDelay;
            _positionChanger.Restart();
            _setupCreator.Restart();
        }

        private void StartBalls() {
            _timer += Time.deltaTime;
            if (_timer >= _creationDelay) {
                _timer = 0;
                StartBall();
            }
        }

        private void StartBall() {
            var ball = Create(_stateManager);
            ball.ToStart();
        }

        private Ball Create(IStateManager manager) {
            var ball = GetBallFromBuffer();
            if (ball == null) {
                var ballModel = new Models.Balls.Ball(new LinearMover(), _positionChanger, _deadZone, _setupCreator);
                ball = Instantiate(_ballPrefab, transform);
                ball.Init(ballModel, manager);
                _ballBuffer.Add(ball);
            }
            return ball;
        }

        private Ball GetBallFromBuffer() {
            foreach (var ball in _ballBuffer) {
                if (ball.Model.State == BallState.IsWait) {
                    return ball;
                }
            }
            return null;
        }
    }
}


