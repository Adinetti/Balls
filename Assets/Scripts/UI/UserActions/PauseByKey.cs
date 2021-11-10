using UnityEngine;

namespace BallsGame.UI.Actions {
    public class PauseByKey : MonoBehaviour, IUserAction {
		[SerializeField] private KeyCode _key = KeyCode.Space;
        private IUserInterface _interface;

        public void Init(IUserInterface userInterface) {
            _interface = userInterface;
        }

        private void Update() {
            if (Input.GetKeyDown(_key)) {
                _interface.Pause();
            }
        }
    }
}


