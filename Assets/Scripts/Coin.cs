using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseGameObject
{

	public float rotationSpeed = 2f;

	public float oscilationAmplitude = 2f;

	private float t;

	void Awake ()
	{
		t = 0f;
	}

	void Update ()
	{
		if (!gamePaused) {
			t = (t + 6f * Time.deltaTime) % (2f * Mathf.PI);
			this.transform.position += Vector3.up * oscilationAmplitude * Mathf.Sin (t) * Time.deltaTime;
			this.transform.Rotate (0f, rotationSpeed, 0f, Space.World);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (!gamePaused) {
			PlayerController player = other.GetComponent<PlayerController> ();

			if (player != null) {
				player.AddCoin ();
				Destroy (this.gameObject);
			}
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
