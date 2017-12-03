using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListeningArea : MonoBehaviour
{

	public EnemyController enemy;

	private Collider listeningArea;


	void OnTriggerEnter (Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController> ();
		if (player != null) {	
			enemy.SetState (new Chasing (this.enemy));
			GameObject.Destroy (this.gameObject);
		}
	}
}
