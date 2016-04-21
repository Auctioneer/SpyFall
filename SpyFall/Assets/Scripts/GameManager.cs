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

	//Method to stop player control
	public IEnumerator DisablePlayerControl(int player)
	{
		print ("We're in gm disable");
		print (player);
		if (player == 1)
		{
			pl = GameObject.Find ("Player1");
			print (pl);
			pl.GetComponent<PlayerController> ().enabled = false;

			yield return new WaitForSeconds (3.0f);

			pl.GetComponent<PlayerController> ().enabled = true;

		}
		else
		{
			pl = GameObject.Find ("Player2");
			print (pl);
			pl.GetComponent<PlayerController> ().DamageAnim ();
			pl.GetComponent<PlayerController> ().enabled = false;

			//yield return new WaitForSeconds (3.0f);


			
		}
	}

	public void resumePlayerControl()
	{
		pl.GetComponent<PlayerController> ().enabled = true;
	}

}
