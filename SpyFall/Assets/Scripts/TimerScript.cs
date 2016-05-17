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
		timerOn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If the timer isn't 0, count down
		if (!timerLength.ToString("0").Equals("0") && (timerOn == true))
		//if (timerOn == true)
		{
			//Timer needs to count down every second in real time
			//This code maps it to real time
			timerLength -= Time.deltaTime;

			//Format this into a string - no decimals
			timerText.text = timerLength.ToString ("0");
		}
		//else
		//{
			//Stop the timer and disable the script (this leaves the UI timer at 0)
			//timerLength = 0.0f;
			//timerOnOff ();
		//}

		//print (timerLength);
	}

	//Switch timer state (can use this when the game ends prematurely)
	public void timerOnOff()
	{
		timerOn = !timerOn;
	}

	//But to be honest this seemed to work better in one instance
	public void timerOff()
	{
		timerOn = false;
	}

	//It's just nice to know what you're setting the variable to, really
	public void timerActive()
	{
		timerOn = true;
	}

	public float getTime()
	{
		return timerLength;
	}

	public string getTimerText()
	{
		return timerText.text;
	}
}