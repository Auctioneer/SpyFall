using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlMenuScript : MonoBehaviour {

	public Button exitControls;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Upon pressing button to exit
	public void exitClick()
	{
		SceneManager.LoadScene ("openingmenu");
	}
}
