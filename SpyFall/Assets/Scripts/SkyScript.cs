using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {

	public static SkyScript clone;

	void Awake()
	{
		//Destroy duplicates of this object
		if (clone)
		{
			DestroyImmediate (gameObject);
		}
		else
		{
			DontDestroyOnLoad (transform.gameObject);
			clone = this;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
