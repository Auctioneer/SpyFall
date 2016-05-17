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
		//BeginTheBegin ();

		//Position the players appropriately
		positionPlayers();
	}

	//Method for positioning the players - takes a few steps hence it has its own method
	void positionPlayers()
	{
		//Get the location of the two starting platforms
		Vector3 platformOnePosition = platformOne.transform.position;
		Vector3 platformTwoPosition = platformTwo.transform.position;
		print (platformOnePosition);
		print (platformTwoPosition);

	}


	// Update is called once per frame
	void Update () 
	{
		
	}

	//Do countdown
	//IEnumerator Countdown()
	//{
		
	//}

	//Life's rich demand creates supply in the hand of the power
	void BeginTheBegin()
	{
		//Enable all the things in the game
		playerDestroyer.SetActive (true);
		platformGenerators.SetActive (true);
		platformOne.GetComponent<MovingPlatform> ().enabled = true;
		platformTwo.GetComponent<MovingPlatform> ().enabled = true;

		//Start the game's timer
		UICanvas.GetComponent<UIManager> ().turnTimerOn ();
	}
}
