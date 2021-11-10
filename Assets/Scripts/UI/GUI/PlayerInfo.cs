using UnityEngine;
using System.Text;
using BallsGame.Models.Players;

namespace BallsGame.UI.GUI {
    [System.Serializable]
    public enum InfoType { Health, LastScore, MaxScore }
    public class PlayerInfo : TextField {
        [SerializeField] private InfoType _infoType;
        [SerializeField] private string _lable = "Lable:";
        private StringBuilder _text;
        private IPlayer _player;
        private int _infoValue;

        protected override void Init() {
            base.Init();
            _player = transform.root.GetComponent<IStateManager>().Player;
            _text = new StringBuilder();
        }

        private void Update() {
            if (IsChanged()) {
                _infoValue = GetValue();
                _text.Clear();
                _text.Append(_lable);
                _text.Append(_infoValue);
                textField.text = _text.ToString();
                Resize();
            }
        }

        public int GetValue() {
            switch (_infoType) {
                case InfoType.Health:
                    return _player.Health;
                case InfoType.LastScore:
                    return _player.Score.Last;
                case InfoType.MaxScore:
                    return _player.Score.Max;
                default:
                    break;
            }
            return 0;
        }

        private bool IsChanged() {
            switch (_infoType) {
                case InfoType.Health:
                    return _infoValue != _player.Health;
                case InfoType.LastScore:
                    return _infoValue != _player.Score.Last;
                case InfoType.MaxScore:
                    return _infoValue != _player.Score.Max;
                default:
                    break;
            }
            return false;            
        }
    }
}


