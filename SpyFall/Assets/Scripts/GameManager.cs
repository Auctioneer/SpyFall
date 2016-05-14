﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameEnded;

	//public GameObject timer;
	public GameObject uiCanvas;

	public delegate void EndGameEvent();
	public static event EndGameEvent EndGame;

	//Need to make a second event for passing details to the UI canvas
	public delegate void EndGamePlayerDetails(int whichPlayerHit);
	public static event EndGamePlayerDetails EndGameUI;

	//Delegate stuff!
	void OnEnable()
	{
		PlayerDestroyer.callEndGame += EndGameInit;
	}

	void OnDisable()
	{
		PlayerDestroyer.callEndGame -= EndGameInit;
	}

	void EndGameInit(int playerHit)
	{
		print ("EndGameInit called " + playerHit);
		EndGameBroadcast ();
		EndGameUIBroadcast (playerHit);

	}



	//Called before start and even if it's not enabled
	//Good for initialising stuff, apparently!
	void Awake()
	{
		gameEnded = false;
	}

	void Update()
	{
		//Check to see if the timer has run down, via the UI Manager
		if ((uiCanvas.GetComponent<UIManager>().getTime() == 0.0f) && (gameEnded == false))
		{
			gameEnded = true;
		}		
			
	}

	//Takes and passes a parameter for the UI
	void EndGameUIBroadcast(int deadPlayer)
	{
		if (EndGameUI != null)
		{
			EndGameUI (deadPlayer);
		}
	}

	void EndGameBroadcast()
	{
		if (EndGame != null)
		{
			EndGame ();
		}
	}

}