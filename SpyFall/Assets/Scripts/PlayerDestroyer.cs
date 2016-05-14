using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	public delegate void callGameManagerEnd(int test);
	public static event callGameManagerEnd callEndGame;

	void OnTriggerEnter2D(Collider2D enterObj)
	{
		if (enterObj.gameObject.tag == "Player") 
		{
			this.enabled = false;
			EndGameCall ();
		} 

	}

	void EndGameCall()
	{
		if (callEndGame != null)
		{
			callEndGame(4);
		}
	}
}
