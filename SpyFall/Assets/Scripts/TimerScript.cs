using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	
	public float timerLength = 30.0f;

	bool timerOn = false;

	public Text timerText;

	// Use this for initialization
	void Start () 
	{
		//Might need to alter this stuff once we code the start of the game
		timerOn = true;
	}

	//Delegate for connecting to Game Manager's EndGame
	void OnEnable()
	{
		GameManager.EndGame += timerOnOff;
	}

	void OnDisable()
	{
		GameManager.EndGame -= timerOnOff;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If the timer isn't 0, count down
		if (!timerLength.ToString("0").Equals("0") && (timerOn == true))
		{
			//Timer needs to count down every second in real time
			//This code maps it to real time
			timerLength -= Time.deltaTime;

			//Format this into a string - no decimals
			timerText.text = timerLength.ToString ("0");
		}
		else
		{
			//Stop the timer and disable the script (this leaves the UI timer at 0)
			timerLength = 0.0f;
			timerOnOff ();

			//Either here or before the line above, we tell the game manager the time has run out
		}

	}

	//Switch timer state (can use this when the game ends prematurely)
	void timerOnOff()
	{
		timerOn = !timerOn;
	}

	public float getTime()
	{
		return timerLength;
	}
}
