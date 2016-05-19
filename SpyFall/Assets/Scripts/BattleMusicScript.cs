using UnityEngine;
using System.Collections;

public class BattleMusicScript : MonoBehaviour {

	AudioSource aud;

	public AudioClip menuMusic;
	public AudioClip battleMusic;
	public AudioClip endMusic;

	public static BattleMusicScript clone;

	//GameObject gameDetails;

	void Awake()
	{
		//Destroy duplicates of this object
		if (clone)
		{
			DestroyImmediate (gameObject);
		}
		else
		{
			DontDestroyOnLoad (transform.gameObject);
			clone = this;
		}
	}

	// Use this for initialization
	void Start () 
	{
		aud = GetComponent<AudioSource> ();

		playMusic ();
		//gameDetails = GameObject.Find ("GameDetails");

	//	if (gameDetails.GetComponent<GameModel> ().isMusicPlaying () == false)
	//	{
		//	playMusic ();
		//}
	}

	// Update is called once per frame
	void Update () {

	}

	void playMusic()
	{
		aud.Play ();
	}

	//When a level loads
	void OnLevelWasLoaded(int level)
	{
		//Opening or controls
		if ((level == 0) || (level == 3))
		{
			if (aud.clip != menuMusic)
			{
				aud.volume = 1;
				aud.clip = menuMusic;
				aud.Play ();
			}
		}
		//Battle
		else if (level == 1)
		{
			if (aud.clip != battleMusic)
			{
				aud.volume = 0.5f;
				aud.clip = battleMusic;
				aud.Play ();
			}
		}
		//End
		else if (level == 2)
		{
			if (aud.clip != endMusic)
			{
				aud.volume = 1;
				aud.clip = endMusic;
				aud.Play ();
			}
		}
		else
		{
			//Do nothing
		}
	}
}
