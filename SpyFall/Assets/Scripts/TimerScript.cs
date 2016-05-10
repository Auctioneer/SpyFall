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

			//Timer needs to count down every second in real time
			//This code maps it to real time
			timerLength -= Time.deltaTime;

			//Format this into a string - no decimals
			timerText.text = timerLength.ToString("0");
	}
}
