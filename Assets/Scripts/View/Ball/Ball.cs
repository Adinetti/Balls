using BallsGame.Models.Balls;
using UnityEngine;

namespace BallsGame.Views {
    [RequireComponent(typeof(MeshCollider))]
    public class Ball : MonoBehaviour {
        private IStateManager _stateManager;
        private Particle _particle;
        private BallMesh _ballMesh;
        
        public IBall Model { get; private set; }

        private void Awake() {
            GetComponent<MeshCollider>().sharedMesh = MeshCreator.Create();
            _particle = GetComponentInChildren<Particle>();
            _ballMesh = GetComponentInChildren<BallMesh>();
        }

        public void Init(IBall model, IStateManager manager) {
            Model = model;
            Model.OnDead += DeadAnimationIsOver;
            Model.OnBlastAnimation += BlastAnimation;
            if (_stateManager == null) {
                _stateManager = manager;
                _stateManager.OnRun += UpdatePosition;
                _stateManager.OnRestart += Restart;
            }
        }

        private void OnDisable() {
            if (_stateManager != null) {
                _stateManager.OnRun -= UpdatePosition;
                _stateManager.OnRestart -= Restart;
            }
        }

        private void Restart() {
            Model.Restart();
            transform.localPosition = Model.Position;
        }

        public void ToStart() {
            Model.ToStart();
            transform.localScale = Vector3.one * Model.Size;
            _ballMesh.Show(Model.Color);
        }

        private void UpdatePosition() {
            Model.Update(_stateManager.Player, Time.deltaTime);
            transform.position = Model.Position;
        }

        private void BlastAnimation() {
            _ballMesh.Hide();
            _particle.Play(Model.Color);
        }

        private bool DeadAnimationIsOver() {
            return _particle.IsStoped;
        }
    }
}


