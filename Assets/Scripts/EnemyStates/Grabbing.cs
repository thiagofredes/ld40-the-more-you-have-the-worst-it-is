using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : EnemyState
{
	float grabTime = 3f;

	PlayerController playerRef;

	public Grabbing (EnemyController enemy)
	{
		this.enemy = enemy;
		playerRef = GameObject.FindObjectOfType<PlayerController> ();
		grabTime = 3f;
		playerRef.StartGrab ();
	}

	public override void Update ()
	{
		if (!enemy.gamePaused) {
			if (Vector3.Distance (this.enemy.transform.position, playerRef.transform.position) > 3f) {
				enemy.SetState (new Chasing (this.enemy));
				playerRef.EndGrab ();
			} else {
				grabTime -= Time.deltaTime;
				if (grabTime <= 0f) {
					Debug.Log ("GAME OVER");
				}
			}
		}
	}

	public override void OnEnter ()
	{
		grabTime = 2f;
	}

	public override void OnExit ()
	{
		base.OnExit ();
	}
}
