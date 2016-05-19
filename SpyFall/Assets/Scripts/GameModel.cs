using UnityEngine;
using System.Collections;

public class GameModel : MonoBehaviour {

	public static GameModel clone;

	int playerOneWins = 0;

	int playerTwoWins = 0;

	int playerOneHits = 0;

	int playerTwoHits = 0;

	bool musicPlaying = false;

	//Stop this from being destroyed between rounds
	void Awake()
	{
		//Destroy duplicates of this object
		if (clone)
		{
			DestroyImmediate (gameObject);
		}
		else
		{
			DontDestroyOnLoad (transform.gameObject);
			clone = this;
		}
	}

	public void musicStarted()
	{
		musicPlaying = true;
	}

	public bool isMusicPlaying()
	{
		return musicPlaying;
	}
		

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

	//Add to a running total of attacks against the other player
	public void addHits (int player, int hits)
	{
		if (player == 1)
		{
			playerOneHits = playerOneHits + hits;
		}
		else if (player == 2)
		{
			playerTwoHits = playerTwoHits + hits;
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

	//Return player one hits
	public int getPlayerOneHits()
	{
		return playerOneHits;
	}

	//Return player two hits
	public int getPlayerTwoHits()
	{
		return playerTwoHits;
	}

	//Resets all the details about the game for when the player restarts
	public void resetAll()
	{
		playerOneWins = 0;
		playerTwoWins = 0;
		playerOneHits = 0;
		playerTwoHits = 0;
	}


}
