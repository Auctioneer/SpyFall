using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndImageScript : MonoBehaviour {

	public Sprite playerOne;
	public Sprite playerTwo;
	public Text winnerText;
	Image img;

	// Use this for initialization
	void Start () 
	{
		img = GetComponent<Image> ();

		if (winnerText.text == "PLAYER 1 WINS!")
		{
			img.sprite = playerOne;
		}
		else
		{
			img.sprite = playerTwo;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
