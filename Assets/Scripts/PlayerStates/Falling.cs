using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : PlayerState
{
	private float fallTime;

	public Falling (PlayerController player)
	{
		this.player = player;
		Debug.Log ("On Falling");
	}

	public override void OnEnter ()
	{
		fallTime = 0f;
	}

	public override void Update ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Vector3 movement = ThirdPersonCameraController.CameraForwardProjectionOnGround * vertical + ThirdPersonCameraController.CameraRightProjectionOnGround * horizontal;

		fallTime += 2f * Time.deltaTime;

		if (movement.magnitude < 0.1f)
			player.transform.rotation = Quaternion.LookRotation (player.transform.forward);
		else
			player.transform.rotation = Quaternion.LookRotation (movement);

		if (player.IsGrounded ()) {
			player.SetState (new Running (this.player));
		}

		//player.animator.SetFloat ("Forward", movement.normalized.magnitude);
		player.characterController.Move (Time.deltaTime * (-Vector3.up * 9.8f * fallTime + 0.75f * movement * player.movementSpeed));
	}
}
