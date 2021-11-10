using UnityEngine;
using System;
using BallsGame.Models.Balls;

namespace BallsGame.Models.Players { 
	public class Player : IPlayer {
        public event Action<IBall> OnKillBall;

        private int _maxHealth = 20;
        public int Health { get; private set; }
		public PlayerScore Score { get; private set; }

        public Player(int maxHealth, IStateManager manager) {
            _maxHealth = maxHealth;
            Health = _maxHealth;
            Score = new PlayerScore(this);
            manager.OnRestart += Restart;
        }

        public void Damage(int damage) {
            damage = Mathf.Abs(damage);
            Health = Mathf.Max(0, Health - damage);
        }

        public void KillBall(IBall ball) {
            ball.Kill();
            OnKillBall?.Invoke(ball);
        }

        private void Restart() {
            Score.ResetLastScore();
            Health = _maxHealth;
        }
    }
}


