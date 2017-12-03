using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GrabCanvasController : MonoBehaviour
{

	public CanvasGroup grabCanvas;

	public Text grabTimeTextInteger;

	public Text grabTimeTextDecimal;

	public Image grabImage;

	public float grabTime = 3f;

	private float originalGrabTime = 3f;

	private Coroutine canvasCoroutine;


	// Use this for initialization
	void Awake ()
	{
		canvasCoroutine = null;
		grabCanvas.alpha = 0f;
		grabTimeTextInteger.text = grabTime.ToString ();
	}

	public void ShowCanvas ()
	{
		if (canvasCoroutine == null)
			canvasCoroutine = StartCoroutine (CanvasCoroutine ());
	}

	public void HideCanvas ()
	{
		if (canvasCoroutine != null) {
			StopCoroutine (canvasCoroutine);
			grabCanvas.alpha = 0f;
			canvasCoroutine = null;
			grabTime = 3f;
		}
	}

	private IEnumerator CanvasCoroutine ()
	{
		int integerPart;
		int decimalPart;
		grabCanvas.alpha = 1f;
		while (grabTime > 0f) {
			grabTime = Mathf.Clamp (grabTime - Time.deltaTime, 0f, 3f);
			integerPart = (int)Math.Truncate (grabTime);
			decimalPart = System.Convert.ToInt16 ((grabTime - integerPart) * 100);
			grabTimeTextInteger.text = integerPart.ToString ("###");
			grabTimeTextDecimal.text = decimalPart.ToString ("##");	
			grabImage.fillAmount = grabTime / originalGrabTime;
			yield return new WaitForEndOfFrame ();
		}
	}
}
