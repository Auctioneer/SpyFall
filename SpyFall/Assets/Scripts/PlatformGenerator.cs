using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] obj;

	//The gap in seconds between spawning objects
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	bool generating = true;

	// Use this for initialization
	void Start () {

		if (generating == true)
		{
			//Call generate the first time to kick things off
			Generate ();
		}
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
		//Create an object?
		Instantiate(obj[Random.Range (0, obj.Length)], transform.position, Quaternion.identity);

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
}
