using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D enterObj)
	{
		if (enterObj.gameObject.tag == "Player") 
		{
			print ("WEW");


		} 

	}
}
