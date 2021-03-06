﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jumping : PlayerState
{
	private float upTime;

	private float totalUpTime;

	private float boostTime;

	private bool boostingJump = false;

	public Jumping (PlayerController player)
	{
		this.player = player;
	}

	public override void OnEnter ()
	{
		upTime = 0.4f;
		totalUpTime = upTime;
		boostTime = 0.5f;
		player.animator.SetTrigger ("jump");
		player.audioSource.PlayOneShot (player.jump);
		if (Input.GetKey (KeyCode.Space)) {
			boostTime -= Time.deltaTime;
			boostingJump = true;
		}
	}

	public override void Update ()
	{
		if (!player.gamePaused && !player.gameEnded) {
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			Vector3 movement = ThirdPersonCameraController.CameraForwardProjectionOnGround * vertical + ThirdPersonCameraController.CameraRightProjectionOnGround * horizontal;

			if (Input.GetKeyUp (KeyCode.Space)) {
				boostingJump = false;
			}

			if (!boostingJump)
				upTime -= Time.deltaTime;
			else {
				boostTime -= Time.deltaTime;
				if (boostTime <= 0f) {
					boostingJump = false;
				}
			}
		
			if (upTime <= 0f) {
				player.SetState (new Falling (this.player));
			} else {
				player.characterController.Move (Time.deltaTime * (Vector3.up * 3f * player.movementSpeed * (upTime / totalUpTime) + 0.9f * movement * player.movementSpeed));
			}
		}
	}
}
