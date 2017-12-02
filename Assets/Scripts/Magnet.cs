using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
	public float baseDistance = 3f;

	public float baseStrength = 2f;

	public float openingAngle = 45f;

	private Collider thisCollider;

	void Awake ()
	{
		thisCollider = GetComponent<MeshCollider> ();
	}

	void OnTriggerStay (Collider other)
	{
		IMagnetic magnetic = other.GetComponent<IMagnetic> ();
		if (magnetic != null) {
			Vector3 direction = other.transform.position - this.transform.position;
			if (Vector3.Angle (this.transform.forward, direction) <= openingAngle) {
				magnetic.Attract (-direction.normalized, baseStrength * (1f - (direction.magnitude / baseDistance)));
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		IMagnetic magnetic = other.GetComponent<IMagnetic> ();
		if (magnetic != null) {
			magnetic.ResetSpeed ();
		}
	}
}
