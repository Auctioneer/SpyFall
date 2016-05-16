using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] obj;
	int[] rotationInts;
	public bool shouldRotate;

	//The gap in seconds between spawning objects
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	//Time to wait before generating the first platform
	//This is given a random value in the initialDelay method
	float initialInterval = 0.4f;

	bool generating = true;

	// Use this for initialization
	void Start () 
	{
		initialiseRotationInts ();
		StartCoroutine (initialDelay ());
	}

	void initialiseRotationInts()
	{
		rotationInts = new int[5];

		for (int i = 0; i < 3; i++)
		{
			rotationInts [i] = 0;
		}

		rotationInts [3] = 20;
		rotationInts [4] = -20;
	}

	//Delegate stuff!
	void OnEnable()
	{
		GameManager.EndGame += StopGeneration;
	}

	void OnDisable()
	{
		GameManager.EndGame -= StopGeneration;
	}


	//Method to generate platforms
	void Generate()
	{
		Quaternion rotation;

		if (shouldRotate == true)
		{
			int rotationInt = rotationInts [Random.Range (0, 5)];
			rotation = Quaternion.Euler (0, 0, rotationInt);
		}
		else
		{
			rotation = Quaternion.identity;
		}

		//Create an object
		Instantiate(obj[Random.Range (0, obj.Length)], transform.position, rotation);



		if (generating == true)
		{
			//Method calls itself again after the interval determined by min and max
			Invoke ("Generate", Random.Range (spawnMin, spawnMax));
		}
	}

	void StopGeneration()
	{
		generating = false;
		Destroy (this);
	}

	IEnumerator initialDelay()
	{
		initialInterval = Random.Range (0, 1.2f);

		yield return new WaitForSeconds (initialInterval);
		Generate ();
	}

}
