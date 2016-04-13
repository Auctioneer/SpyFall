using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	public delegate void callGameManagerEnd();
	public static event callGameManagerEnd callEndGame;

	void OnTriggerEnter2D(Collider2D enterObj)
	{
		if (enterObj.gameObject.tag == "Player") 
		{
			callEndGame ();
			//We can get the player's name this way
			//print (enterObj.gameObject.name);
		} 

	}

	void EndGameCall()
	{
		if (callEndGame != null)
		{
			callEndGame();
		}
	}
}
