using BallsGame.Models.Players;
using System;
using UnityEngine;

namespace BallsGame.Models.Balls {
    public delegate bool IsDead();
    public interface IBall {
        event IsDead OnDead;
        event Action OnBlastAnimation;
        Vector3 Position { get; }
        float Size { get; }
        int Price { get; }
        float Speed { get; }
        BallState State { get; }
        Color Color { get; }
        int Damage { get; }
        void ToStart();
        void Kill();
        void Update(IPlayer player);
        void Restart();
    }
}
