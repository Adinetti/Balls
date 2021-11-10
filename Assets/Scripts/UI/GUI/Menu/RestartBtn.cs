using UnityEngine;
using UnityEngine.EventSystems;
using BallsGame.UI.Actions;

namespace BallsGame.UI.GUI.MainMenu {
    public class RestartBtn : MonoBehaviour, IPointerClickHandler, IUserAction {
        private IUserInterface _interface;

        public void Init(IUserInterface userInterface) {
            _interface = userInterface;
        }

        public void OnPointerClick(PointerEventData eventData) {
            _interface.Restart();
        }
    }
}


