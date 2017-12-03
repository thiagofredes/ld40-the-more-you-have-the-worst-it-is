using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController> ();
		if (other != null) {
			GameManager.EndGame (false);
		}
	}
}
