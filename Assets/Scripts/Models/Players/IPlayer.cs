using BallsGame.Models.Balls;
using System;

namespace BallsGame.Models.Players { 
	public interface IPlayer {
        event Action<IBall> OnKillBall;
        int Health { get; }
        PlayerScore Score { get; }
        void KillBall(IBall ball);
        void Damage(int damage);
    }
}


