using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : EnemyState
{
	int currentPatrolPoint = 0;

	private Coroutine patrollingCoroutine;

	public Patrolling (EnemyController enemy)
	{
		Debug.Log ("Patrolling");
		this.enemy = enemy;
		this.enemy.magnet.active = false;
		patrollingCoroutine = enemy.StartCoroutine (Patrol ());
	}

	public override void OnEnter ()
	{
		
	}

	public override void OnExit ()
	{
		enemy.StopCoroutine (patrollingCoroutine);
		enemy.navMeshAgent.ResetPath ();
	}

	public override void Update ()
	{
		base.Update ();
	}

	private IEnumerator Patrol ()
	{
		YieldInstruction endOfFrame = new WaitForEndOfFrame ();
		while (true) {
			enemy.navMeshAgent.SetDestination (PatrolPointsController.GetPointFor (enemy.number, currentPatrolPoint).position);
			while (enemy.navMeshAgent.pathPending) {
				yield return endOfFrame;
			}
			while (Vector3.Distance (enemy.navMeshAgent.transform.position, PatrolPointsController.GetPointFor (enemy.number, currentPatrolPoint).position) > 0.5f) {
				yield return endOfFrame;
			}
			currentPatrolPoint = (currentPatrolPoint + 1) % PatrolPointsController.GetNumPointsFor (enemy.number);
		}
	}
}
