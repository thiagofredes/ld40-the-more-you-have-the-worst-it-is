using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : EnemyState
{
	float grabTime = 2f;

	GameObject playerRef;

	public Grabbing (EnemyController enemy)
	{
		Debug.Log ("Grabbing");
		this.enemy = enemy;
		playerRef = GameObject.FindGameObjectWithTag ("Player");
		grabTime = 2f;
	}

	public override void Update ()
	{
		if (Vector3.Distance (this.enemy.transform.position, playerRef.transform.position) > 3f) {
			enemy.SetState (new Chasing (this.enemy));
		} else {
			grabTime -= Time.deltaTime;
			if (grabTime <= 0f) {
				Debug.Log ("GAME OVER");
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
