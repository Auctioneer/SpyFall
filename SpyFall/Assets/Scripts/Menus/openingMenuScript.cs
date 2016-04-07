using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class openingMenuScript : MonoBehaviour {

	//Menu items
	public Text spyFallText;
	public Button playText;
	public Button exitText;

	//Canvases
	public Canvas startMenu;
	public Canvas quitMenu;


	//Initialise
	void Start () 
	{
		//Get components from hierarchy with respective names
		startMenu = startMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();

		//Quit should not be visible until the quit button is pressed
		quitMenu.enabled = false;

		spyFallText = spyFallText.GetComponent<Text> ();
		playText = playText.GetComponent<Button> ();
		exitText = playText.GetComponent<Button> ();

	}

	//When the user presses 'Quit'
	public void QuitButton()
	{
		//Show menu
		quitMenu.enabled = true;
		playText.enabled = false;
		exitText.enabled = false;
	}

	//User clicks no in quit menu
	public void QuitNo()
	{
		//Go back to main menu view
		quitMenu.enabled = false;
		playText.enabled = true;
		exitText.enabled = true;
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


}
