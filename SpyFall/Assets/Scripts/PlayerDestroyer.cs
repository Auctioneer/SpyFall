using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	public delegate void callGameManagerEnd(int test);
	public static event callGameManagerEnd callEndGame;

	void OnTriggerEnter2D(Collider2D enterObj)
	{
		GameObject whatObject = enterObj.gameObject;

		if (whatObject.tag == "Player") 
		{
			int playerDead = whatObject.GetComponent<PlayerController> ().getPlayerNumber ();
			print ("Collided with " + playerDead);
			this.enabled = false;
			print ("Now calling EndGameCall in PlayerDestroyer");
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
