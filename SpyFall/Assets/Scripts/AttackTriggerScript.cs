using UnityEngine;
using System.Collections;

public class AttackTriggerScript : MonoBehaviour {

	//Method to disable player's attack trigger when collision happens
	public delegate void DisableAttackTrigger();
	public static event DisableAttackTrigger DisableTrigger;


	//Destroys every object it touches
	void OnTriggerEnter2D(Collider2D enterObject)
	{
		//If statement there just in case any of the UI elements overlap above the canvas
		if (enterObject.tag == "Player")
		{
			//Call the player's take damage function
			enterObject.gameObject.GetComponent<PlayerController>().TakeDamage();

			//Then disable both the players' attack triggers
			EndAttack();

		}
	}

	//Calls EndAttack in PlayerController
	void EndAttack()
	{
		if (DisableTrigger != null)
		{
			DisableTrigger ();
		}
	}
		
}