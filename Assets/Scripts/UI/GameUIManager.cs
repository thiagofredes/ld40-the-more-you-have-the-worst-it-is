using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{

	public GameObject pauseScreen;

	public GameObject gameOverScreen;

	public Text coinNumber;

	public int coinsRemaining;

	public ExitController exit;

	private static GameUIManager _instance;


	void Awake ()
	{
		GameManager.GamePaused += GameManager_GamePaused;
		GameManager.GameResumed += GameManager_GameResumed;
		GameManager.GameEnded += GameManager_GameEnded;
		pauseScreen.SetActive (false);
		gameOverScreen.SetActive (false);
		_instance = this;
	}

	void GameManager_GameEnded (bool success)
	{
		if (!success) {
			gameOverScreen.SetActive (true);
		}
	}

	void OnDisable ()
	{
		GameManager.GamePaused -= GameManager_GamePaused;
		GameManager.GameResumed -= GameManager_GameResumed;
		GameManager.GameEnded -= GameManager_GameEnded;
	}

	void GameManager_GameResumed ()
	{
		pauseScreen.SetActive (false);
	}

	void GameManager_GamePaused ()
	{
		pauseScreen.SetActive (true);
	}

	public static void SetCoinText (int number)
	{
		_instance.coinNumber.text = (_instance.coinsRemaining - number).ToString ();
		if (_instance.coinsRemaining - number == 0) {
			_instance.exit.Activate ();
		}
	}
}
