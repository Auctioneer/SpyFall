using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameEnded;

	//public GameObject timer;
	public GameObject uiCanvas;

	public delegate void EndGameEvent();
	public static event EndGameEvent EndGame;

	//Need to make a second event for passing details to the UI canvas
	public delegate void EndGamePlayerDetails(int playerOneScore, int playerTwoScore);
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

	void EndGameInit(int test)
	{
		print ("EndGameInit called " + test);
		EndGameBroadcast ();

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

	void EndGameBroadcast()
	{
		if (EndGame != null)
		{
			EndGame ();
		}
	}

}
