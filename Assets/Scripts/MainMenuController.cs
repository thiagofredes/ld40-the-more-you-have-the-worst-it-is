using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuController : MonoBehaviour
{

	public GameObject initialScreen;

	public GameObject howToPlayScreen;

	public GameObject backButton;

	public GameObject bgmController;

	void Awake ()
	{
		GameObject bgmCtrl = GameObject.FindGameObjectWithTag ("BGMController");
		if (bgmCtrl != null)
			GameObject.Destroy (bgmCtrl);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}
	// Use this for initialization
	void Start ()
	{
		backButton.SetActive (false);
		howToPlayScreen.SetActive (false);
	}

	public void HowToPlay ()
	{
		howToPlayScreen.SetActive (true);
		initialScreen.SetActive (false);
		backButton.SetActive (true);
	}

	public void Back ()
	{
		howToPlayScreen.SetActive (false);
		initialScreen.SetActive (true);
		backButton.SetActive (false);
	}

	public void Exit ()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	public void StartGame ()
	{
		GameObject bgmCtrl = (GameObject)Instantiate (bgmController);
		GameObject.DontDestroyOnLoad (bgmCtrl);
		SceneManager.LoadSceneAsync ("Phase1");

	}
}
