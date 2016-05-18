using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Boolean to say whether the player has control over their character or not
	bool playerControl = true;

	public float maxSpeed = 10f;
	bool facingRight = true;

	Rigidbody2D rb2d;
	Animator anim;
	AudioSource aud;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	//Not sure if this is necessary, but we may be passing keys in as parameters so the tag number could be useful
	public int playerNumber = 1;
	public string jumpButton = "Jump_P1";
	public string horizontalControl = "Horizontal_P1";
	public string attackButton = "Attack_P1";

	public float damageTime = 1.0f;
	int hitCounter = 0;
	bool doubleJump = false;

	//Attack hitbox
	public BoxCollider2D attackTrigger;

	//Hit counter text
	public Text hitText;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		aud = GetComponent<AudioSource> ();

		//We start with the attackTrigger disabled
		attackTrigger.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{

		if (playerControl == true)
		{
			//Change this to name rather than code
			if ((grounded || !doubleJump) && Input.GetButtonDown (jumpButton))
			{
				anim.SetBool ("Ground", false);
				rb2d.AddForce (new Vector2 (0, jumpForce));

				if (!doubleJump && !grounded)
					doubleJump = true;
			}
			else if (Input.GetButtonDown (attackButton))
			{
				Attack ();
			}
		}
	}

	void FixedUpdate()
	{

		if (playerNumber == 1)
		{
			print (playerControl);
		}

		//NOTE: Moved this down there because they weren't landing on platforms at the start
		//if (playerControl == true)
		//{
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

			anim.SetBool ("Ground", grounded);

			if (grounded)
				doubleJump = false;

			anim.SetFloat ("verticalSpeed", rb2d.velocity.y);

		if (playerControl == true)
		{
			float move = Input.GetAxis (horizontalControl);

			anim.SetFloat ("speed", Mathf.Abs (move));

			rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);

			if (move > -0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
		}
	}

	//Method to flip the player character
	public void Flip()
	{
		facingRight = !facingRight;
		//Vector3 Scale = transform.localScale;
		//Scale.x *= -1;
		//transform.localScale = Scale;
		anim.transform.Rotate(0,180,0);
	}


	//Method to run an attack
	void Attack()
	{
		attackTrigger.enabled = true;

		//Play attack animation
		anim.SetTrigger ("Attack");

	}
		

	//Upon finishing the attack animation
	public void EndAttack()
	{
		//Remove the attack trigger
		attackTrigger.enabled = false;
	}

	//Method for when the player is hit by the other
	//Needs to be an IEnumerator because it's a timing thing - it's a coroutine
	public IEnumerator playerDamage()
	{
		print ("in playerdamage");
		attackTrigger.enabled = false;

		//Move the player to the 'hurt' layer so the other player can pass through them
		this.gameObject.layer = LayerMask.NameToLayer("HurtPlayer");

		print ("Player is in hurtplayer layer.");
		anim.SetTrigger ("Damage");

		//Stop player movement for the duration of the damage time
		yield return new WaitForSeconds (damageTime);

		//Move player back to Player layer
		this.gameObject.layer = LayerMask.NameToLayer("Player");

	}

	//Method to update the player's hit counter
	void UpdateHits()
	{
		//Add one to number of hits on the other player's UI
		//Will need to be a method to update this after
		hitCounter++;

		print (hitCounter);

		//We need to get the specific component
		hitText.text = hitCounter.ToString ();
	}

	public void TakeDamage()
	{
		print ("takedamage in player called");

		//Now update the hit counter
		UpdateHits();

		//Flip player control
		PlayerControlOnOff ();

		//We can't disable the box collider because it'll fall through and we need platforms to be able to act on it
		//So we'll make sure it can't collide with the player layer

		StartCoroutine(playerDamage ());
	}

	//Method for playing the player's death animation
	public void Die()
	{
		aud.Play ();

		print ("We're in Die()");
		anim.SetBool("Ground", true);
		anim.SetTrigger ("Dead");
	}
		

	//Delegate stuff!
	void OnEnable()
	{
		GameManager.EndGame += PlayerEndGame;
		AttackTriggerScript.DisableTrigger += EndAttack;
	}

	void OnDisable()
	{
		GameManager.EndGame -= PlayerEndGame;
		AttackTriggerScript.DisableTrigger -= EndAttack;
	}

	//Method for running the steps to end the game for all players
	void PlayerEndGame()
	{
		PlayerControlOnOff ();
		this.rb2d.gravityScale = 0;
		this.rb2d.velocity = Vector3.zero;

	}

	//Method for giving control to players or taking it away
	public void PlayerControlOnOff()
	{
		playerControl = !playerControl;
	}

	//Runs after animation
	//Simpler than the flip method in this case
	void ResumeControlFromDamage()
	{
		playerControl = true;
	}

	//For getting which player it is
	public int getPlayerNumber()
	{
		return playerNumber;
	}

	//Removing the player character once the death animation plays
	public void playerDestroy()
	{
		Destroy(this.gameObject);
	}
		
}