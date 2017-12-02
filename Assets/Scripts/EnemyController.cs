using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public NavMeshAgent navMeshAgent;

	public CharacterController characterController;

	public Magnet magnet;

	public int number;

	private EnemyState currentState;

	void Start ()
	{
		this.currentState = new Patrolling (this);
	}

	void Update ()
	{
		this.currentState.Update ();
	}

	public void SetState (EnemyState newState)
	{
		this.currentState.OnExit ();
		this.currentState = newState;
		this.currentState.OnEnter ();
	}

	void OnTriggerEnter (Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController> ();
		if (player != null) {
			SetState (new Chasing (this));
		}
	}
}
