using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : EnemyState
{
	int currentPatrolPoint = 0;

	public Patrolling (EnemyController enemy)
	{
		this.enemy = enemy;
		enemy.StartCoroutine (Patrol ());
	}

	public override void OnEnter ()
	{
		
	}

	public override void OnExit ()
	{
		base.OnExit ();
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
