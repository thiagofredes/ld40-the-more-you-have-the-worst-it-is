using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : BaseGameObject
{
	public NavMeshAgent navMeshAgent;

	public CharacterController characterController;

	public Magnet magnet;

	public int number;

	public Animator animator;

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

	public void Damage ()
	{
		SetState (new Dizzy (this));
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
