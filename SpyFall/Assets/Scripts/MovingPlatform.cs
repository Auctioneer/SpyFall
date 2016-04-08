using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float verticalSpeed = 1;

	//If false, platform should use Vector3 for movement instead, which will make it rotate
	public bool useVectorTwo = true;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		Move ();

	}

	void Move()
	{
		//Vector 2 makes it rotate
		//Vector 3 keeps it straight

		if (useVectorTwo == true)
		{
			Vector2 vec = new Vector2 (0f, 1 * verticalSpeed);
			this.transform.Translate (vec * Time.deltaTime);
		}
		else
		{
			Vector3 vec = new Vector3 (0f, 1 * verticalSpeed);
			this.transform.Translate (vec * Time.deltaTime);
		}


	}
}
