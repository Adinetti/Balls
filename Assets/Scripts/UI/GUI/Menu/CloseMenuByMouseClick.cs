using UnityEngine;
using UnityEngine.EventSystems;

namespace BallsGame.UI.GUI.MainMenu { 
    [RequireComponent(typeof(Menu))]
	public class CloseMenuByMouseClick : MonoBehaviour {
        [SerializeField] private MouseButtonName _button;
		private Menu _menu;

        private void Awake() {
            _menu = GetComponent<Menu>();
        }

        private void Update() {
            if (_menu.IsOpen) {
                if (Input.GetMouseButtonDown((int)_button)) {
                    if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject()) {
                        _menu.Close();
                    }
                }
            }
        }
    }
}


