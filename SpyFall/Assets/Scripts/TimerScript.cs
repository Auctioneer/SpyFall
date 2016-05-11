using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	public float timerLength = 30.0f;

	public Text timerText;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If the timer isn't 0, count down
		if (!timerLength.ToString("0").Equals("0"))
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
			this.enabled = false;

			//Either here or before the line above, we tell the game manager the time has run out
		}

	}
}
