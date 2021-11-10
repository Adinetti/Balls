using UnityEngine;
using System;
using BallsGame.Models.Players;
using BallsGame.Models.Balls.Movers;

namespace BallsGame.Models.Balls {
    [Serializable]
    public enum BallState { IsWait, IsDead, IsRun }

    public class Ball : IBall {
        public event IsDead OnDead;
        public event Action OnBlastAnimation;

        private IBallMover _mover;
        private BallSetupCreator _setupCreator;
        private PositionChanger _positionChanger;
        private IDeadZone _deadZone;

        public BallState State { get; private set; }
        public int Price { get; private set; }
        public float Speed { get; private set; }
        public Vector3 Position { get; private set; }
        public float Size { get; private set; }
        public Color Color { get; private set; }
        public int Damage { get; private set; }

        public Ball(IBallMover ballMover, PositionChanger positionChanger, IDeadZone deadZone, BallSetupCreator setupCreator) {
            _mover = ballMover;
            _deadZone = deadZone;
            _setupCreator = setupCreator;
            _positionChanger = positionChanger;
            Restart();
        }

        public void Restart() {
            Price = _setupCreator.CreatePrice();
            Speed = _setupCreator.CreateSpeed();
            Size = _setupCreator.CreateSize();
            Damage = _setupCreator.CreateDamage();
            Color = _setupCreator.CreateColor();
            Position = _positionChanger.CreateBallPosition(Size);
            State = BallState.IsWait;
        }

        public void ToStart() {
            State = BallState.IsRun;
        }

        public void Update(IPlayer player) {
            switch (State) {
                case BallState.IsRun:
                    Position = _mover.GetNextPostion(this, Time.deltaTime);
                    if (InDeadZone()) {
                        Blast(player);
                    }
                    break;
                case BallState.IsDead:
                    if (OnDead == null || OnDead()) {
                        Restart();
                    }
                    break;
                default:
                    break;
            }
        }

        private bool InDeadZone() {
            var topPoint = Position.y + .5 * Size;
            return _deadZone.Position.y > topPoint;
        }

        public void Kill() {
            if (State == BallState.IsRun) {
                OnBlastAnimation?.Invoke();
                State = BallState.IsDead;
            }
        }

        private void Blast(IPlayer player) {
            if (State == BallState.IsRun) {
                player.Damage(Damage);
                State = BallState.IsDead;
            }
        }
    }
}


