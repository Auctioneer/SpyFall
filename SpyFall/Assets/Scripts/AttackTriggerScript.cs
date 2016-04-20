using UnityEngine;
using System.Collections;

public class AttackTriggerScript : MonoBehaviour {

	public delegate void PlayerDamage();
	public static event PlayerDamage causeDamage;

	//Destroys every object it touches
	void OnTriggerEnter2D(Collider2D enterObject)
	{
		//If statement there just in case any of the UI elements overlap above the canvas
		if (enterObject.tag == "Player")
		{
			//Call the player's take damage function
			StartCauseDamage();

		}
	}

	void StartCauseDamage()
	{
		print ("startcausedamage in attack trigger called");
		if (causeDamage != null)
		{
			causeDamage();
		}
	}


		
}