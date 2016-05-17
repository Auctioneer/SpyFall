using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour {

	public GameObject playerOne;
	public GameObject playerTwo;

	public Canvas UICanvas;

	//Left and right initial platforms
	public GameObject platformOne;
	public GameObject platformTwo;

	public GameObject platformGenerators;

	public GameObject playerDestroyer;

	// Use this for initialization
	void Start () 
	{
		playerDestroyer.SetActive (false);
		platformGenerators.SetActive (false);
		BeginTheBegin ();
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	//Life's rich demand creates supply in the hand of the power
	void BeginTheBegin()
	{
		//Enable all the things in the game
		playerDestroyer.SetActive (true);
		platformGenerators.SetActive (true);
		platformOne.GetComponent<MovingPlatform> ().enabled = true;
		platformTwo.GetComponent<MovingPlatform> ().enabled = true;
	}
}
