using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

	public float rotationSpeed = 2f;

	public float oscilationAmplitude = 2f;

	void Update ()
	{
		this.transform.position += Vector3.up * oscilationAmplitude * Mathf.Sin (Time.time % 2 * Mathf.PI) * Time.deltaTime;
		this.transform.Rotate (0f, rotationSpeed, 0f, Space.World);
	}

	void OnTriggerEnter (Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController> ();

		if (player != null) {
			player.AddCoin ();
			Destroy (this.gameObject);
		}
	}
}
