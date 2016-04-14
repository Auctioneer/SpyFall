using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	//X and Y co-ordinates to change in inspector
	//0,0 is bottom left of camera view
	public int xCo = 0;
	public int yCo = 0;

	// Use this for initialization
	void Start () 
	{
		Vector3 location;

		if (this.gameObject.name == "LeftBumper")
		{
			location = Camera.main.ScreenToWorldPoint (new Vector3 (xCo, yCo, 5));
		}
		else
		{
			location = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width + xCo, yCo, 5));
		}
		this.transform.position = location;
	}

}
