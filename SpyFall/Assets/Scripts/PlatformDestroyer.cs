﻿using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	//Destroys every object it touches
	void OnTriggerEnter2D(Collider2D enterObject)
	{
		//If statement there just in case any of the UI elements overlap above the canvas
		if ((enterObject.tag != "Default") && (enterObject.tag != "UI") && (enterObject.tag != "Player") && (enterObject.tag != "Bumper")) 
		{
			Destroy (enterObject.gameObject);
		}
	}

	public Vector3 getPosition()
	{
		return this.gameObject.transform.position;
	}


}
