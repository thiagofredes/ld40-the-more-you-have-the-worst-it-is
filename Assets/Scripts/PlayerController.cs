using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController characterController;

	public float movementSpeed = 5f;

	private PlayerState currentState;


	void Start ()
	{
		currentState = new Running (this);
	}

	void Update ()
	{
		currentState.Update ();
	}

	public void SetState (PlayerState newState)
	{
		currentState.OnExit ();
		currentState = newState;
		currentState.OnEnter ();
	}

	public bool IsGrounded ()
	{
		RaycastHit groundHit;
		Vector3 rayOrigin = this.transform.position;
		float raycastDistance = this.characterController.height * 0.5f;
		float sphereRadius = this.characterController.radius;

		if (Physics.SphereCast (rayOrigin, sphereRadius, -Vector3.up, out groundHit, raycastDistance, ~LayerMask.GetMask ("Player"))) {
			this.characterController.Move (-Vector3.up * (sphereRadius + this.characterController.skinWidth));
			return true;
		}

		return false;
	}
}
