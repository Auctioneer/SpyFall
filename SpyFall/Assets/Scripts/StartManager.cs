using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour {

	public GameObject playerOne;
	public GameObject playerTwo;

	public Canvas UICanvas;

	//Left and right initial platforms
	public GameObject platformOne;
	public GameObject platformTwo;

	public GameObject platformGenerators;

	public GameObject playerDestroyer;

	// Use this for initialization
	void Start () 
	{
		//Stop a few things here
		playerDestroyer.SetActive (false);
		platformGenerators.SetActive (false);
		UICanvas.GetComponent<UIManager> ().hideGameTimer ();

		//Position the players appropriately
		positionPlayers();

		//Get the countdown timer going
		doCountdown();
	}

	//Method for positioning the players - takes a few steps hence it has its own method
	void positionPlayers()
	{
		
		//Get the location of the two starting platforms
		Vector3 platformOnePosition = platformOne.transform.position;
		Vector3 platformTwoPosition = platformTwo.transform.position;

		//And the player destroyer, which they'll fall from
		Vector3 playerDestPos = playerDestroyer.transform.position;

		//Place the players above the platforms and have them drop
		Vector3 playerOnePosition = new Vector3 (platformOnePosition.x, playerDestPos.y);
		playerOne.transform.position = playerOnePosition;

		Vector3 playerTwoPosition = new Vector3 (platformTwoPosition.x, playerDestPos.y);
		playerTwo.transform.position = playerTwoPosition;

	}

	//Get that timer working
	void doCountdown()
	{
		//StartSequence() runs the countdown timer
		UICanvas.GetComponent<UIManager> ().StartSequence ();
	}


	//Delegate stuff for when the initial countdown timer finishes
	void OnEnable()
	{
		UIManager.StartGame += BeginTheBegin;
	}

	void OnDisable()
	{
		UIManager.StartGame -= BeginTheBegin;
	}




	//Life's rich demand creates supply in the hand of the power
	void BeginTheBegin()
	{
		//Enable all the things in the game
		playerDestroyer.SetActive (true);
		platformGenerators.SetActive (true);
		platformOne.GetComponent<MovingPlatform> ().enabled = true;
		platformTwo.GetComponent<MovingPlatform> ().enabled = true;

		//Enable the game timer
		UICanvas.GetComponent<UIManager>().showGameTimer();

		//Start the game's timer
		UICanvas.GetComponent<UIManager> ().turnTimerOn ();

		//Disable the countdown timer
		UICanvas.GetComponent<UIManager>().hideStartTimer();

	}
}
