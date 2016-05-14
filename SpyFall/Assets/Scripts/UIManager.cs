using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text playerOneHits;
	public Text playerTwoHits;
	public Text winnerText;

	public GameObject timer;

	//Because the world needs more delegates
	void OnEnable()
	{
		GameManager.EndGame += UIEndGame;
	}

	void OnDisable()
	{
		GameManager.EndGame -= UIEndGame;
	}



	// Use this for initialization
	void Start () 
	{
		//We only display the winner when the game is actually won
		winnerText.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Returns the current time for the GameManager
	//MVC up this motha
	public float getTime()
	{
		return timer.GetComponent<TimerScript> ().getTime ();
	}

	void disableAll()
	{
		playerOneHits.enabled = false;
		playerTwoHits.enabled = false;
		winnerText.enabled = false;
	}

	//End game events for user interface
	void UIEndGame()
	{
		//We use this as a code for the winner in displayWinner()
		int winID;

		print ("Running UI end game");

		//Right now we'll just say it's a draw until we can work out who won
		//Note: In the event of a tie, the player with the most hits wins

		//Remember that the number of hits in the UI refers to how many hits were laid on that player
		//So we'll flip it here
		int playerOneInt = int.Parse(playerTwoHits.text);
		int playerTwoInt = int.Parse(playerOneHits.text);

		if (playerOneInt > playerTwoInt)
		{
			winID = 1;
		}
		else if (playerTwoInt > playerOneInt)
		{
			winID = 2;
		}
		else
		{
			winID = 0;
		}

		print ("WinID = " + winID);

		displayWinner(winID);
	}





	//Displays the winner text on the screen
	void displayWinner(int winID)
	{
		//winID refers to which player won


		//0 = draw
		switch (winID)
		{
		case 0:
			winnerText.text = "Draw!";
			break;
		case 1:
			winnerText.text = "Player 1 wins!";
			break;
		case 2:
			winnerText.text = "Player 2 wins!";
			break;
		default:
			winnerText.text = "Well, this shouldn't have happened.";	
			break;
		}

		winnerText.enabled = true;
	}
}
