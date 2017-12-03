using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{

	public ParticleSystem particles;

	public Collider activator;

	public string nextScene;

	private bool active = false;

	// Use this for initialization
	void Start ()
	{
		activator.enabled = false;
		particles.gameObject.SetActive (false);
	}

	public void Activate ()
	{
		active = true;
		particles.gameObject.SetActive (true);
		particles.Play ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (active) {
			PlayerController player = other.GetComponent<PlayerController> ();
			if (player != null) {
				SceneManager.LoadSceneAsync (nextScene);
			}
		}
	}
}
