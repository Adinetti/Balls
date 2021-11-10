using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BallsGame.UI.GUI {
	[RequireComponent(typeof(RectTransform), typeof(TMPro.TextMeshProUGUI))]
	public abstract class TextField : MonoBehaviour {
		protected TMPro.TextMeshProUGUI textField;
		protected RectTransform rect;

        private void Start() {
            Init();
        }

        protected virtual void Init() {
            rect = GetComponent<RectTransform>();
            textField = GetComponent<TMPro.TextMeshProUGUI>();
        }

        protected void Resize() {
            var text = textField.text;
            rect.sizeDelta = textField.GetPreferredValues(text);
        }
    }
}


