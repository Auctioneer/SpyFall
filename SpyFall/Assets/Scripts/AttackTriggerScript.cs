using UnityEngine;
using System.Collections;

public class AttackTriggerScript : MonoBehaviour {

	//Destroys every object it touches
	void OnTriggerEnter2D(Collider2D enterObject)
	{
		//If statement there just in case any of the UI elements overlap above the canvas
		if (enterObject.tag == "Player")
		{
			//Call the player's take damage function
			enterObject.gameObject.GetComponent<PlayerController>().TakeDamage();

		}
	}
		
}