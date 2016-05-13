using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameEnded;

	public GameObject timer;

	public delegate void EndGameEvent();
	public static event EndGameEvent EndGame;

	//Delegate stuff!
	void OnEnable()
	{
		PlayerDestroyer.callEndGame += EndGameInit;
	}

	void OnDisable()
	{
		PlayerDestroyer.callEndGame -= EndGameInit;
	}

	void EndGameInit()
	{
		print ("EndGameInit called");
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
		//Check to see if the timer has run down
		if ((timer.GetComponent<TimerScript>().getTime () == 0.0f) && (gameEnded == false))
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
