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

	public AudioSource audioSource;

	[HideInInspector]
	public bool allowChaseByListening;

	private EnemyState currentState;


	void Start ()
	{
		allowChaseByListening = true;
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
