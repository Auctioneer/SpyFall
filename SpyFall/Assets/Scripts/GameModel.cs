using UnityEngine;
using System.Collections;

public class GameModel : MonoBehaviour {

	int playerOneWins = 0;

	int playerTwoWins = 0;

	//Stop this from being destroyed between rounds
	void Awake()
	{
		print ("Sup I awake!");
		DontDestroyOnLoad (transform.gameObject);
	}

	//Might need to use this to destroy the object on the win screen
	//void OnLevelWasLoaded(int level)
	//{
		
	//}

	//Add to player wins
	public void addToWinCount(int player)
	{
		if (player == 2)
		{
			playerOneWins++;
		}
		else if (player == 1)
		{
			playerTwoWins++;
		}
	}

	//Return player one counter
	public int getPlayerOneWins()
	{
		return playerOneWins;
	}

	//Return player two counter
	public int getPlayerTwoWins()
	{
		return playerTwoWins;
	}

	//Resets all the details about the game for when the player restarts
	public void resetAll()
	{
		playerOneWins = 0;
		playerTwoWins = 0;
	}


}
