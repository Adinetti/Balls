using UnityEngine;
using BallsGame.UI.Actions;
using BallsGame.Models.Balls;

namespace BallsGame.UI { 
	public class UserInterface : MonoBehaviour, IUserInterface {
        private GameStateManager _gameManager;
		private IUserAction[] _userActions;

        private void Awake() {
            _gameManager = transform.root.GetComponent<GameStateManager>();
            _userActions = _gameManager.GetComponentsInChildren<IUserAction>();
        }

        private void Start() {
            for (int i = 0; i < _userActions.Length; i++) {
                _userActions[i].Init(this);
            }
        }

        public void Pause() {
            _gameManager.SetPause(_gameManager.State == GameState.IsRun);
        }

        public void Restart() {
            _gameManager.Restart();
        }

        public void KillBall(IBall ball) {
            if (_gameManager.State == GameState.IsRun && ball.State == BallState.IsRun) {
                _gameManager.Player.KillBall(ball);
            }
        }
    }
}


