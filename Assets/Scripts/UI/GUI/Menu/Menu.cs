using UnityEngine;

namespace BallsGame.UI.GUI.MainMenu {
    public class Menu : MonoBehaviour {
        private IStateManager _stateManager;
        private RectTransform _rectTransform;
        private Vector2 _closePosition = new Vector2(1000, 1000);
        private GameState _gameState;

        public bool IsOpen => _rectTransform.anchoredPosition == Vector2.zero;
        public bool IsClose => IsOpen == false;

        private void Awake() {
            _stateManager = transform.root.GetComponent<GameStateManager>();
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchoredPosition = _closePosition;
        }

        private void Update() {
            if (_stateManager.State != _gameState) {
                _gameState = _stateManager.State;
                _rectTransform.anchoredPosition = _gameState == GameState.IsRun ? _closePosition : Vector2.zero;
            }
        }

        public void Close() {
            _stateManager.SetPause(false);
            if (_stateManager.State == GameState.IsRun) {
                _rectTransform.anchoredPosition = _closePosition;
            }
        }
    }
}


