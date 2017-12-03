using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

	public GameObject pauseScreen;

	public Text coinNumber;

	public int coinsRemaining;

	private static GameUIManager _instance;


	void Awake ()
	{
		GameManager.GamePaused += GameManager_GamePaused;
		GameManager.GameResumed += GameManager_GameResumed;
		pauseScreen.SetActive (false);
		_instance = this;
	}

	void OnDisable ()
	{
		GameManager.GamePaused -= GameManager_GamePaused;
		GameManager.GameResumed -= GameManager_GameResumed;
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
	}
}
