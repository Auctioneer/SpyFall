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
			this.enabled = false;
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
