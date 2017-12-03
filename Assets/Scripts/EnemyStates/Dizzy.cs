using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dizzy : EnemyState
{

	float dizzyTime = 2f;

	PlayerController playerRef;

	public Dizzy (EnemyController enemy)
	{
		this.enemy = enemy;
		playerRef = GameObject.FindObjectOfType<PlayerController> ();
		playerRef.EndGrab ();
	}

	public override void Update ()
	{
		if (!enemy.gamePaused) {
			dizzyTime -= Time.deltaTime;
			if (dizzyTime <= -0f) {
				enemy.SetState (new Chasing (this.enemy));
			}
		}
	}

	public override void OnEnter ()
	{
		base.OnEnter ();
	}

	public override void OnExit ()
	{
		base.OnExit ();
	}
}
