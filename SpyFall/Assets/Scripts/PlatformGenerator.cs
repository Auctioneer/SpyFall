using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] obj;

	//The gap in seconds between spawning objects
	public float spawnMin = 1f;
	public float spawnMax = 2f;


	// Use this for initialization
	void Start () {

		//Call generate the first time to kick things off
		Generate ();
	}


	//Method to generate platforms
	void Generate()
	{
		//Create an object?
		Instantiate(obj[Random.Range (0, obj.Length)], transform.position, Quaternion.identity);

		//Method calls itself again after the interval determined by min and max
		Invoke("Generate", Random.Range(spawnMin, spawnMax));
	}
}
