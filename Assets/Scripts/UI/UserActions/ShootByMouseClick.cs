using UnityEngine;
using BallsGame.Views;

namespace BallsGame.UI.Actions {
    public class ShootByMouseClick : MonoBehaviour, IUserAction {
        [SerializeField] private MouseButtonName _button;
        private IStateManager _stateManager;
        private IUserInterface _interface;
        private Camera _camera;

        private void Awake() {
            _camera = Camera.main;
            _stateManager = transform.root.GetComponent<IStateManager>();
        }

        private void OnEnable() {
            _stateManager.OnRun += Click;
        }

        private void OnDisable() {
            _stateManager.OnRun -= Click;
        }

        public void Init(IUserInterface userInterface) {
            _interface = userInterface;
        }

        private void Click() {
            if (Input.GetMouseButtonDown((int)_button)) {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit)) {
                    var ball = hit.transform.GetComponent<Ball>();
                    if (ball != null) {
                        _interface.KillBall(ball.Model);
                    }
                }
            }
        }
    }
}


