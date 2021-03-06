﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dizzy : EnemyState
{

	float dizzyTime = 3f;

	PlayerController playerRef;

	public Dizzy (EnemyController enemy)
	{
		//Debug.Log ("Dizzy");
		this.enemy = enemy;
		dizzyTime = 3f;
		playerRef = GameObject.FindObjectOfType<PlayerController> ();
		playerRef.EndGrab ();
		enemy.audioSource.Play ();
		enemy.animator.SetTrigger ("dizzy");
		enemy.particles.Stop ();
	}

	public override void Update ()
	{
		if (!enemy.gamePaused && !enemy.gameEnded) {
			dizzyTime -= Time.deltaTime;
			if (dizzyTime <= 0f) {
				enemy.SetState (new Chasing (this.enemy));
			}
		}
	}

	public override void OnEnter ()
	{
		dizzyTime = 3f;
	}

	public override void OnExit ()
	{
		base.OnExit ();
	}
}
