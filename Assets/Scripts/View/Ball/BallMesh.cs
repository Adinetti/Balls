using UnityEngine;

namespace BallsGame.Views { 
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class BallMesh : MonoBehaviour {
		private MeshRenderer _renderer;
        private MeshFilter _meshFilter;

        private void Awake() {
            _renderer = GetComponent<MeshRenderer>();
            _meshFilter = GetComponent<MeshFilter>();
            _meshFilter.mesh = MeshCreator.Create();
        }

        public void Show(Color color) {
            transform.localScale = Vector3.one;            
            _renderer.material.SetColor("_Color", color);
        }

        public void Hide() {
            transform.localScale = Vector3.zero;
        }
    }
}


