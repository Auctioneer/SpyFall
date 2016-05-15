using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text playerOneHits;
	public Text playerTwoHits;
	public Text winnerText;

	public GameObject timer;

	//Need to make a second event for passing details to the UI canvas
	public delegate void EndGameTimerZero(int negativeOne);
	public static event EndGameTimerZero EndGameTimer;
	bool endGameTimerBool = false;

	//Because the world needs more delegates
	//#Bernie2016
	void OnEnable()
	{
		GameManager.EndGameUI += UIEndGame;
	}

	void OnDisable()
	{
		GameManager.EndGameUI -= UIEndGame;
	}

	// Use this for initialization
	void Start () 
	{
		//We only display the winner when the game is actually won
		winnerText.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((endGameTimerBool == false) && (getTimeText ().Equals("0")))
		{
			endGameTimerBool = true;
			endGameTimerInit ();
		}
	}

	void endGameTimerInit()
	{
		if (EndGameTimer != null)
		{
			EndGameTimer (-1);
		}
	}

	//Returns the current time for the GameManager
	//MVC up in this motha
	public float getTime()
	{
		return timer.GetComponent<TimerScript> ().getTime ();
	}

	//Overload for string
	public string getTimeText()
	{
		return timer.GetComponent<TimerScript> ().getTimerText ();
	}

	void disableAll()
	{
		playerOneHits.enabled = false;
		playerTwoHits.enabled = false;
		winnerText.enabled = false;
	}

	//End game events for user interface
	void UIEndGame(int whichPlayerHit)
	{
		//Turn timer off
		timer.GetComponent<TimerScript> ().timerOff ();

		print ("Running UI end game");

		print ("Which player hit the top: " + whichPlayerHit);

		if (whichPlayerHit == -1)
		{
			decideWinner ();
		}
		else
		{
			displayWinner (whichPlayerHit);
		}

	}

	//Decide winner in the event of a draw
	void decideWinner()
	{
		//We use this as a code for the winner in displayWinner()
		int winID;

		//Right now we'll just say it's a draw until we can work out who won
		//Note: In the event of a tie, the player with the most hits wins

		//Remember that the number of hits in the UI refers to how many hits were laid on that player
		//So we'll flip it here
		int playerOneInt = int.Parse(playerTwoHits.text);
		int playerTwoInt = int.Parse(playerOneHits.text);

		if (playerOneInt > playerTwoInt)
		{
			winID = 2;
		}
		else if (playerTwoInt > playerOneInt)
		{
			winID = 1;
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
		//winID refers to which player lost

		print ("Win ID = " + winID);

		//0 = draw
		switch (winID)
		{
		case 0:
			winnerText.text = "Draw!";
			break;
		case 1:
			winnerText.text = "Player 2 wins!";
			break;
		case 2:
			winnerText.text = "Player 1 wins!";
			break;
		default:
			winnerText.text = "Well, this shouldn't have happened.";	
			break;
		}

		winnerText.enabled = true;
	}
}
