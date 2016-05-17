using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class openingMenuScript : MonoBehaviour {

	//Menu items
	public Text spyFallText;
	public Button playText;
	public Button exitText;
	public Button controlsText;

	//Canvases
	public Canvas startMenu;
	public Canvas quitMenu;
	public Canvas controls;

	//Initialise
	void Start () 
	{
		//Get components from hierarchy with respective names
		startMenu = startMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		controls = controls.GetComponent<Canvas> ();

		//Quit should not be visible until the quit button is pressed
		quitMenu.enabled = false;

		//Neither should the contols window
		controls.enabled = false;

		spyFallText = spyFallText.GetComponent<Text> ();
		playText = playText.GetComponent<Button> ();
		exitText = playText.GetComponent<Button> ();

	}

	//When the user presses 'Quit'
	public void QuitButton()
	{
		//Show menu
		quitMenu.enabled = true;
		DisableMainMenu ();
	}

	//User clicks no in quit menu
	public void QuitNo()
	{
		//Go back to main menu view
		quitMenu.enabled = false;
		EnableMainMenu ();
	}

	//Load the fight
	//Should this happen here or later? Leave it for now
	//Should we go to a transition scene
	public void PlayButton()
	{
		SceneManager.LoadScene ("battlemain");
	}


	//Exit the game
	public void QuitGame()
	{
		Application.Quit ();
	}

	//Show control scheme
	public void ViewControls ()
	{
		controls.enabled = true;
		DisableMainMenu ();
	}

	//Back button within view controls to go back to main menu
	public void HideControls()
	{
		controls.enabled = false;
		EnableMainMenu ();
	}

	void DisableMainMenu()
	{
		playText.enabled = false;
		exitText.enabled = false;
		controlsText.enabled = false;
	}

	void EnableMainMenu()
	{
		playText.enabled = true;
		exitText.enabled = true;
		controlsText.enabled = true;
	}

}
