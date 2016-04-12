using UnityEngine;
//For sliders, buttons, text, etc. If we need them.
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	//Pause panel
	public GameObject panel;

	//Whether the game is paused or not
	public bool paused;



	// Use this for initialization
	void Start () 
	{
		//Game starts unpaused
		paused = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (paused == true) 
		{
			Pause (true);
		}
		else
		{
			Pause (false);
		}

		if (Input.GetButtonDown ("Cancel")) 
		{
			ChangePauseState ();
		}
	}

	void Pause(bool state)
	{
		if (state == true) 
		{
			//Make panel appear
			panel.SetActive (true);

			//Stop time
			Time.timeScale = 0.0f;
		}
		else 
		{
			//Hide panel and resume time
			panel.SetActive (false);
			Time.timeScale = 1.0f;
		}
	}

	//Flip pause state
	public void ChangePauseState()
	{
		paused = !paused;
	}

	public void Quit()
	{
		SceneManager.LoadScene ("openingmenu");
	}
}
