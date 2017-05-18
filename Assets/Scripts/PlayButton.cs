using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class PlayButton : MonoBehaviour, GazeResponder {

	private Image image;
	public GameObject rainStart;
	public Sprite defaultState;
	public Color defaultColor;

	public Sprite hoverState;
	public Color hoverColor;

	public Sprite downState;
	public Color downColor;

	public Sprite clickedState;

	public UnityEvent OnGazeStart;
	public UnityEvent OnGazeEnd;
	public UnityEvent OnGazeInput;
	public UnityEvent OnGazeInputEnd;

	void Start()
	{
		image = gameObject.GetComponent<Image>();
	}

	bool isGazing = false;
	bool isClicked = false;
	public void OnGazeEnter()
	{
		isGazing = true;

		OnGazeStart.Invoke();

		if (!isClicked && hoverState != null) {
			image.sprite = hoverState;
		} 

	}

	public void OnGazeExit()
	{
		isGazing = false; 

		OnGazeEnd.Invoke();

		if (!isClicked && defaultState != null) {
			image.sprite = defaultState;
		} 
	}

	public void OnGazeTrigger()
	{
		if (isClicked) {
			isClicked = false;
			rainStart.SetActive (true);
		} else {
			isClicked = true;
			rainStart.SetActive (false);
		}

		OnGazeInput.Invoke();

		if(downState != null)
			image.sprite = downState;

		image.color = downColor;
	}

	public void OnGazeTriggerEnd()
	{
		OnGazeInputEnd.Invoke();

		if (isGazing && defaultState != null && !isClicked)
		{
			image.sprite = hoverState;
		}
		else if( hoverState != null && !isClicked)
		{
			image.sprite = defaultState;
		}

		if(isGazing && defaultState != null && !isClicked)
		{
			image.color = hoverColor;
		}
		else if( hoverState != null && !isClicked)
		{
			image.color = defaultColor;
		}

		if (isClicked && clickedState != null) {
			image.sprite = clickedState;
		} else if(!isClicked){
			image.color = defaultColor;
		}
	}

}
