using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jumping : PlayerState
{
	private PlayerController player;

	public Jumping (PlayerController player)
	{
		this.player = player;
		Debug.Log ("On Jumping");
	}
}
