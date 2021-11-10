using UnityEngine;

namespace BallsGame.Views { 
    [RequireComponent(typeof(ParticleSystem))]
	public class Particle : MonoBehaviour {
		private ParticleSystem _particle;
        private ParticleSystem.MainModule _mainSetting;
        private ParticleSystemRenderer _renderer;

        public bool IsStoped => _particle.isStopped;

        private void Awake() {
            _particle = GetComponent<ParticleSystem>();
            _particle.Stop();
            _renderer = _particle.GetComponent<ParticleSystemRenderer>();
            _renderer.renderMode = ParticleSystemRenderMode.Mesh;
            _renderer.mesh = MeshCreator.Create();
        }

        public void Play(Color color) {
            if (IsStoped) {
                transform.localPosition = Vector3.zero;
                _renderer.material.SetColor("_Color", color);
                _particle.Play();
            }            
        }

        public void Restart() {
            transform.localPosition = new Vector3(0, 10000, 0);
            _particle?.Stop();
        }
    }
}


