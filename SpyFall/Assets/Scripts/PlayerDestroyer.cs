using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	public delegate void callGameManagerEnd(int test);
	public static event callGameManagerEnd callEndGame;

	//We need this to set the position of playerDestroyer relative to this
	public GameObject platformDestroyer;

	void Start()
	{
		Vector3 platformDestroyerVec = platformDestroyer.GetComponent<PlatformDestroyer> ().getPosition ();

		//Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height - 600, 5));
		//this.transform.Translate (position);

		print (platformDestroyerVec);

		//Vector3 pdPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, platformDestroyerVec.y, 5));
		Vector3 pdPos = new Vector3(Screen.width / 2, platformDestroyerVec.y - 2, 5);

		//this.transform.position = pdPos;

		print (pdPos);

	}

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
