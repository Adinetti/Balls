using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BallsGame.UI.Actions { 	
	public interface IUserAction  {
		void Init(IUserInterface userInterface);
	}
}


