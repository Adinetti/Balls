using UnityEngine;
using UnityEngine.EventSystems;
using BallsGame.UI.Actions;

namespace BallsGame.UI.GUI {
    public class PauseBtn : MonoBehaviour, IUserAction, IPointerClickHandler  {
        private IUserInterface _interface;

        public void Init(IUserInterface userInterface) {
            _interface = userInterface;
        }

        public void OnPointerClick(PointerEventData eventData) {
            _interface.Pause();
        }
    }
}


