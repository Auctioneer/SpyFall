using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinnerDisplay : MonoBehaviour {

	public Text winnerText;
	public Text playerOneHitText;
	public Text playerTwoHitText;
	public Text finalScore;

	int playerOneScore;
	int playerTwoScore;
	int playerOneHits;
	int playerTwoHits;

	GameObject gameDetails;

	// Use this for initialization
	void Start () 
	{
		//Get the object containing player scores
		gameDetails = GameObject.Find ("GameDetails");
	
		//Get win count
		playerOneScore = gameDetails.GetComponent<GameModel> ().getPlayerOneWins ();
		playerTwoScore = gameDetails.GetComponent<GameModel> ().getPlayerTwoWins ();

		//Get hit count
		playerOneHits = gameDetails.GetComponent<GameModel> ().getPlayerOneHits ();
		playerTwoHits = gameDetails.GetComponent<GameModel> ().getPlayerTwoHits ();

		getWinner ();

		displayScore ();

		displayHits ();

	}

	void getWinner ()
	{
		if (playerOneScore > playerTwoScore)
		{
			winnerText.text = "PLAYER 1 WINS!";
		}
		else
		{
			winnerText.text = "PLAYER 2 WINS!";
		}
	}

	void displayScore()
	{
		finalScore.text = playerOneScore + " - " + playerTwoScore;
	}

	void displayHits()
	{
		playerOneHitText.text = "Hits: " + playerOneHits;
		playerTwoHitText.text = "Hits: " + playerTwoHits;
	}

}
