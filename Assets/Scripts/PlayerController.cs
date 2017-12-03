using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : BaseGameObject
{
	public CharacterController characterController;

	public float movementSpeed = 5f;

	public string[] layersToIgnoreWhenFalling;

	private int numCoins;

	public GrabCanvasController grabCanvas;

	public Animator animator;

	public float UnscaledMovementSpeed {
		get { return this.originalMovementSpeed; }
	}

	private PlayerState currentState;

	private float originalMovementSpeed;

	void Start ()
	{
		originalMovementSpeed = movementSpeed;
		currentState = new Running (this);
		numCoins = 0;
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
		Vector3 rayOrigin = this.transform.position + characterController.center;
		float raycastDistance = this.characterController.height * 0.5f + characterController.skinWidth;
		float sphereRadius = this.characterController.radius;

		if (Physics.SphereCast (rayOrigin, sphereRadius, -Vector3.up, out groundHit, raycastDistance, ~LayerMask.GetMask (layersToIgnoreWhenFalling))) {
			this.characterController.Move (-Vector3.up * (sphereRadius + this.characterController.skinWidth));
			Debug.Log ("grounded");
			return true;
		}

		Debug.Log ("not grounded");
		return false;
	}

	public bool IsOnEnemyHead ()
	{
		RaycastHit enemyHit;
		Vector3 rayOrigin = this.transform.position + characterController.center;
		float raycastDistance = this.characterController.height * 0.5f + characterController.skinWidth;
		float sphereRadius = this.characterController.radius;

		if (Physics.SphereCast (rayOrigin, sphereRadius, -Vector3.up, out enemyHit, raycastDistance, LayerMask.GetMask ("Enemies"))) {
			this.characterController.Move (-Vector3.up * (sphereRadius + this.characterController.skinWidth));
			EnemyController enemyController = enemyHit.collider.gameObject.GetComponent<EnemyController> ();
			enemyController.Damage ();
			return true;
		}

		return false;
	}


	public void Attract (Vector3 direction, float strength)
	{
		this.movementSpeed = originalMovementSpeed - strength;
		this.characterController.Move (direction * strength * Time.deltaTime);
	}

	public void ResetSpeed ()
	{
		this.movementSpeed = originalMovementSpeed;
	}

	public int GetNumCoins ()
	{
		return numCoins;
	}

	public void AddCoin ()
	{
		numCoins++;
		GameUIManager.SetCoinText (numCoins);
	}

	public void StartGrab ()
	{
		grabCanvas.ShowCanvas ();
	}

	public void EndGrab ()
	{
		grabCanvas.HideCanvas ();
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
