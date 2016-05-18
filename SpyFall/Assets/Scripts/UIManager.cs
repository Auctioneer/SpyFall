using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public Text playerOneHits;
	public Text playerTwoHits;
	public Text winnerText;

	//For total wins across rounds
	public Text playerOneWins;
	public Text playerTwoWins;
	public GameObject gameDetails;

	public GameObject timer;
	public GameObject startTimer;

	//Need to make a second event for passing details to the UI canvas
	public delegate void EndGameTimerZero(int negativeOne);
	public static event EndGameTimerZero EndGameTimer;

	//Telling the Start Manager the game is starting
	public delegate void StartGameTimerZero();
	public static event StartGameTimerZero StartGame;

	bool endGameTimerBool = false;
	bool startGameTimerBool = false;

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
		gameDetails = GameObject.Find ("GameDetails");

		//We only display the winner when the game is actually won
		winnerText.enabled = false;

		//Update the win counts for each player
		playerOneWins.text = gameDetails.GetComponent<GameModel>().getPlayerOneWins().ToString();
		print (playerOneWins);
		playerTwoWins.text = gameDetails.GetComponent<GameModel>().getPlayerTwoWins().ToString();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((endGameTimerBool == false) && (getTimeText ().Equals("0")))
		{
			endGameTimerBool = true;
			endGameTimerInit ();
		}
		else if ((startGameTimerBool == false) && (getStartTimeText().Equals("0")))
		{
			startGameTimerBool = true;
			startGameInit ();

		}
	}

	void endGameTimerInit()
	{
		if (EndGameTimer != null)
		{
			EndGameTimer (-1);
		}
	}

	void startGameInit()
	{
		if (StartGame != null)
		{
			StartGame();
		}
	}

	//Returns the current time for the GameManager
	//MVC up in this motha
	public float getTime()
	{
		return timer.GetComponent<TimerScript> ().getTime ();
	}

	//Get time in string form
	public string getTimeText()
	{
		return timer.GetComponent<TimerScript> ().getTimerText ();
	}

	//Get start timer in string form
	public string getStartTimeText()
	{
		return startTimer.GetComponent<TimerScript> ().getTimerText ();
	}

	//Get rid of everything
	//Well, not quite everything
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

		//If nobody has reached 5 points
		if (checkForWinner() == false)
		{
			//Next round
			StartCoroutine (delayThenGameRestart ());
		}
		else
		{
			//Else end game
			StartCoroutine (delayThenGameEnd ());
		}

	}

	//Check at the end of every round to see if someone reached five hits first
	bool checkForWinner()
	{
		if ((gameDetails.GetComponent<GameModel>().getPlayerOneWins() == 5) || (gameDetails.GetComponent<GameModel>().getPlayerTwoWins() == 5))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	//Using at the start from StartManager, to turn timer on
	public void turnTimerOn()
	{
		timer.GetComponent<TimerScript> ().timerActive ();
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

		print ("Gonna add");
		//Add it to the GameManager win count
		gameDetails.GetComponent<GameModel> ().addToWinCount (winID);
		winnerText.enabled = true;
	}


	//Start sequence countdown
	public void StartSequence()
	{
		startTimer.GetComponent<TimerScript> ().timerActive ();
	}

	//Hide the starting time after game start
	public void hideStartTimer()
	{
		startTimer.GetComponent<TimerScript> ().hideTimer ();
	}

	//Hide the game timer until game start
	public void hideGameTimer()
	{
		timer.GetComponent<TimerScript> ().hideTimer ();
	}

	//Show the timer upon ggame start
	public void showGameTimer()
	{
		timer.GetComponent<TimerScript> ().showTimer ();
	}

	//Method to add to GameDetails' player score
	void addToPlayerScore(int whichPlayer)
	{
		gameDetails.GetComponent<GameModel> ().addToWinCount (whichPlayer);
	}

	//Run this just before reloading the level
	//Only do this if both scores are less than 5 - do check before calling method
	IEnumerator delayThenGameRestart()
	{
		print ("Inside the coroutine");

		//Two second delay
		yield return new WaitForSeconds (2.0f);

		//Reload the level
		SceneManager.LoadScene("battlemain");
	}

	//Run when a player hits 5 wins
	IEnumerator delayThenGameEnd()
	{
		print ("Inside the coroutine");

		//Two second delay
		yield return new WaitForSeconds (2.0f);

		//Go to end game screen
		SceneManager.LoadScene("endgame");
	}

}
