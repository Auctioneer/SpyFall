using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	//X and Y co-ordinates to change in inspector
	//0,0 is bottom left of camera view
	public int xCo = 0;
	public int yCo = 0;

	//Position of object in world
	Vector3 location;

	//Initialization
	void Start () 
	{
		//Code for the side bumpers
		if (this.gameObject.tag == "Bumper")
		{

			if (this.gameObject.name == "LeftBumper")
			{
				location = Camera.main.ScreenToWorldPoint (new Vector3 (xCo, yCo, 5));
			}
			else
			{
				location = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width + xCo, yCo, 5));
			}
		}

		//Code for the initial platforms the players are to stand on
		//200 should be y co-ordinate
		else
		{
			if (this.gameObject.name == "LeftInitialPlatform")
			{
				location = Camera.main.ScreenToWorldPoint (new Vector3 ((Screen.width/2) - xCo, yCo, 5));
			}
			else
			{
				location = Camera.main.ScreenToWorldPoint (new Vector3 ((Screen.width/2) + xCo, yCo, 5));
			}
			
		}
		this.transform.position = location;
	}

	//Method to return locaton
	public Vector3 getLocation()
	{
		return location;
	}

}
