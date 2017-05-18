using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeSpriteButton : MonoBehaviour, GazeResponder 
{
	private Image image;
	public bool playGame;
	public bool exitGame;
	public bool menuGame;
	public bool scoreGame;
	public GameObject rainStart;
	public Sprite defaultState;
	public Color defaultColor;
	public AudioSource firstAudio;
	public AudioSource secondAudio;
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

		} else {
			isClicked = true;

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
			if (playGame) {
				rainStart.GetComponent<RainIt> ().startRain ();
			}
			if (menuGame) {
				firstAudio.Stop ();
				secondAudio.Stop ();
			}
		} else if(!isClicked){
			image.color = defaultColor;
			if (playGame) {
				rainStart.GetComponent<RainIt> ().stopRain ();
			}
			if (menuGame) {
				firstAudio.Play ();
				secondAudio.Play ();
			}
		}
	}


}
