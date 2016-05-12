using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text playerOneHits;
	public Text playerTwoHits;
	public Text winnerText;

	// Use this for initialization
	void Start () 
	{
		//We only display the winner when the game is actually won
		winnerText.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void disableAll()
	{
		playerOneHits.enabled = false;
		playerTwoHits.enabled = false;
		winnerText.enabled = false;
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
		case 1:
			winnerText.text = "Player 1 wins!";
		case 2:
			winnerText.text = "Player 2 wins!";
		default:
			winnerText.text = "Well, this shouldn't have happened.";	
		}
	}
}
