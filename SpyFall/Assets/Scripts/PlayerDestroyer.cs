using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	public delegate void callGameManagerEnd(int test);
	public static event callGameManagerEnd callEndGame;

	void OnTriggerEnter2D(Collider2D enterObj)
	{
		GameObject whatObject = enterObj.gameObject;

		//Might need to write a case later on for both players hitting the top
		//Don't worry though, could just do a brief check of their y positions in GameManager once a player hits

		if (whatObject.tag == "Player") 
		{
			int playerDead = whatObject.GetComponent<PlayerController> ().getPlayerNumber ();
			print ("Collided with " + playerDead);

			//Play player's death animation here
			//Better here than playercontroller because then it would run for both players
			whatObject.GetComponent<PlayerController> ().Die ();

			this.enabled = false;
			EndGameCall (playerDead);
		}

	}

	void EndGameCall(int playerDead)
	{
		if (callEndGame != null)
		{
			callEndGame(playerDead);
		}
	}
}
