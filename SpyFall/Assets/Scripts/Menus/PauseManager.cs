using UnityEngine;
//For sliders, buttons, text, etc. If we need them.
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	//Pause panel
	public GameObject pausePanel;

	//Whether the game is paused or not
	public bool paused;

	//Whether the options menu is visible or not
	bool optionsOn;

	// Use this for initialization
	void Start () 
	{
		//Game starts unpaused
		paused = false;

		//And the options menu hidden too
		optionsOn = false;
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

		if (Input.GetButtonDown ("Cancel") && (optionsOn == false)) 
		{
			ChangePauseState ();
		}
	}

	void Pause(bool state)
	{
		if (state == true) 
		{
			//Make panel appear
			pausePanel.SetActive (true);

			//Stop time
			Time.timeScale = 0.0f;
		}
		else 
		{
			//Hide panel and resume time
			pausePanel.SetActive (false);
			Time.timeScale = 1.0f;
		}
	}

	//Flip pause state
	public void ChangePauseState()
	{
		paused = !paused;
	}

	//Quit game and go to opening menu
	public void Quit()
	{
		SceneManager.LoadScene ("openingmenu");
	}

	//Open the options panel
	public void OpenOptions()
	{
		
	}

	//Reload the scene
	public void RestartLevel()
	{
		SceneManager.LoadScene ("battlemain");
	}
}