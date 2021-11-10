using UnityEngine;
using BallsGame.Views;

namespace BallsGame.Models.Balls {
    public class BallSetupCreator {
        [SerializeField] private BallSetup _ranges;
        private float _acceleration;

        public BallSetupCreator(BallSetup ranges) {
            _ranges = ranges;
            Restart();
        }

        public void Restart() {
            _acceleration = 0;
        }

        public float CreateSize() => Random.Range(_ranges.size.min, _ranges.size.max);
        public int CreatePrice() => Random.Range(_ranges.price.min, _ranges.price.max + 1);
        public int CreateDamage() => Random.Range(_ranges.damage.min, _ranges.damage.max + 1);
        public float CreateSpeed() {
            var speed = Random.Range(_ranges.speed.min, _ranges.speed.max) + _acceleration;
            _acceleration += _ranges.speed.accleration;
            return speed;
        }

        public Color CreateColor() {
            var color = Color.white;
            color.r = Random.Range(0f, 1f);
            color.g = Random.Range(0f, 1f);
            color.b = Random.Range(0f, 1f);
            return color;
        }
    }
}


