using BallsGame.Models.Players;
using System;

namespace BallsGame { 
	public interface IStateManager  {
		event Action OnRun;
		event Action OnRestart;
		GameState State { get; }
		IPlayer Player { get; }
		void SetPause(bool pause);
		void Restart();
	}
}


