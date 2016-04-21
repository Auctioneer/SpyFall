using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameEnded;

	public delegate void EndGameEvent();
	public static event EndGameEvent EndGame;

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
