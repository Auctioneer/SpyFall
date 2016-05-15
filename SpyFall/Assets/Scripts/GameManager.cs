using UnityEngine;
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
		// I don't think we should check time every frame.
		//Just get UI manager to say when it's at zero

		print ("penis");
		float currentTime = uiCanvas.GetComponent<UIManager> ().getTime ();

		//Check to see if the timer has run down, via the UI Manager
		//if ((uiCanvas.GetComponent<UIManager>().getTime() == 0.0f) && (gameEnded == false))
		if (currentTime < 0.2f)
		{
			print ("SHOOP DA WOOP THE TIMER'S AT ZERO!");
			gameEnded = true;
			EndGameInit (-1);
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