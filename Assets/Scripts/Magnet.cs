using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : BaseGameObject
{
	[System.Serializable]
	public class MagnetismLevel
	{
		public int coinCount;
		public float baseStrength;
	}

	public MagnetismLevel[] levels;

	public float baseDistance = 3f;

	public float openingAngle = 45f;

	public bool active;

	private int currentLevel;

	private int numLevels;

	private Collider thisCollider;


	void Awake ()
	{
		thisCollider = GetComponent<MeshCollider> ();
		numLevels = levels.Length;
		currentLevel = 0;
		active = false;
	}

	void OnTriggerStay (Collider other)
	{
		if (!gamePaused) {
			PlayerController player = other.GetComponent<PlayerController> ();
			if (active) {
				if (player != null) {
					Vector3 direction = other.transform.position - this.transform.position;
					if (Vector3.Angle (this.transform.forward, direction) <= openingAngle) {
						SetMagnetismLevel (player.GetNumCoins ());
						player.Attract (-direction.normalized, levels [currentLevel].baseStrength * (1f - (direction.magnitude / baseDistance)));
					}
				}
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (!gamePaused) {
			PlayerController magnetic = other.GetComponent<PlayerController> ();
			if (active) {
				if (magnetic != null) {
					magnetic.ResetSpeed ();
				}
			}
		}
	}

	private void SetMagnetismLevel (int coinCount)
	{
		currentLevel = 0;
		for (int l = 0; l < numLevels; l++) {
			if (levels [l].coinCount <= coinCount) {
				currentLevel = l;
			}
		}
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
