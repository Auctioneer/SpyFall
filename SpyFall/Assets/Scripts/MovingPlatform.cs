using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float verticalSpeed = 1;

	//If false, platform should use Vector3 for movement instead, which will make it rotate
	public bool useVectorTwo = true;

	//Stops the move method being called when this changes in StopMoving
	bool currentlyMoving = true;

	//Delegate stuff!
	void OnEnable()
	{
		GameManager.EndGame += StopMoving;
	}

	void OnDisable()
	{
		GameManager.EndGame -= StopMoving;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if (currentlyMoving == true)
		{
			Move ();
		}

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

	//Method to make the platform stop moving when the game ends
	void StopMoving()
	{
		currentlyMoving = false;

		//Get rid of any off-screen platforms
		if (this.transform.position.y < -13)
		{
			Destroy (this.gameObject);
		}
	}
}
