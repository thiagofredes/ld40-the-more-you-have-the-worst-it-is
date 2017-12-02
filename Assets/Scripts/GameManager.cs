using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameManager : MonoBehaviour
{
	private bool paused = false;

	public static event Action GamePaused;

	public static event Action GameEnded;

	public static event Action GameResumed;

	public static void Pause ()
	{
		if (GamePaused != null)
			GamePaused ();
	}

	public static void Resume ()
	{
		if (GameResumed != null)
			GameResumed ();
	}

	public static void EndGame ()
	{
		if (GameEnded != null)
			GameEnded ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!paused) {
				Pause ();
			} else {
				Resume ();
			}
			paused = !paused;
		}
	}
}
