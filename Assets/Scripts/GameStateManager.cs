using UnityEngine;
using System;
using BallsGame.Models.Players;

namespace BallsGame {
    [SerializeField]
    public enum GameState { IsRun, IsPause, IsOver, IsRestart }

    public class GameStateManager : MonoBehaviour, IStateManager {
        [SerializeField] private int _maxPlayerHealth = 50;

        public event Action OnRun;
        public event Action OnRestart;

        public GameState State { get; private set; }
        public IPlayer Player { get; private set; }

        private void Awake() {
            Player = new Player(_maxPlayerHealth, this);
        }

        private void Update() {
            switch (State) {
                case GameState.IsRun:
                    OnRun?.Invoke();
                    if (Player.Health <= 0) {
                        State = GameState.IsOver;
                    }
                    break;
                case GameState.IsRestart:
                    OnRestart?.Invoke();
                    Time.timeScale = 1;
                    State = GameState.IsRun;
                    break;
                default:
                    break;
            }
        }

        public void SetPause(bool pause) {
            if (State == GameState.IsRun || State == GameState.IsPause) {
                State = pause ? GameState.IsPause : GameState.IsRun;
            }
            Time.timeScale = State == GameState.IsPause ? 0 : 1;
        }

        public void Restart() {
            State = GameState.IsRestart;
        }
    }
}


