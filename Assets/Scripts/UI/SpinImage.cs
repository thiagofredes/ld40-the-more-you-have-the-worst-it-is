using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinImage : BaseGameObject
{

	// Update is called once per frame
	void Update ()
	{
		if (!gamePaused) {
			this.transform.Rotate (0f, 10f * Time.deltaTime, 0f);
		}			
	}

	protected override void OnGamePaused ()
	{
		gamePaused = true;
	}

	protected override void OnGameEnded ()
	{
		gameEnded = true;
	}

	protected override void OnGameResumed ()
	{
		gamePaused = false;
	}
}
