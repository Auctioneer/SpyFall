using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameEnded;

	public GameObject timer;

	public delegate void EndGameEvent();
	public static event EndGameEvent EndGame;

	//What does this do? I think the answer is nothing
	GameObject pl;


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
		if (timer.GetComponent<TimerScript>().getTime () == 0.0f)
		{
			gameEnded = true;
		}		

		//This condition is otherwise fulfulled when a player hits the top of the screen
		if (gameEnded == true)
			EndGameBroadcast ();
	}

	void EndGameBroadcast()
	{
		if (EndGame != null)
		{
			EndGame ();
		}
	}

}
