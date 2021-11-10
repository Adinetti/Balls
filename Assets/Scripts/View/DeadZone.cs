using BallsGame.Models.Balls;
using UnityEngine;

namespace BallsGame.Views {
    public class DeadZone : MonoBehaviour, IDeadZone {
        public Vector3 Position => transform.position;

        private void Awake() {
            transform.position = Camera.main.ScreenToWorldPoint(Vector3.zero);
        }
    }
}


