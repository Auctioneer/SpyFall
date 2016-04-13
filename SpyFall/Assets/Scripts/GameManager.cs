using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameEnded;

	public delegate void EndGameEvent();
	public static event EndGameEvent EndGame;

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
