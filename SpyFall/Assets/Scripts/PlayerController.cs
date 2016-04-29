using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Boolean to say whether the player has control over their character or not
	bool playerControl = true;

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool attacking = false;

	Rigidbody2D rb2d;
	Animator anim;

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



	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

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
				//Not sure I need the bool, given the way I've written this
				attacking = true;
				Attack ();
			}
		}
	}

	void FixedUpdate()
	{

		if (playerControl == true)
		{
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

			anim.SetBool ("Ground", grounded);

			if (grounded)
				doubleJump = false;

			anim.SetFloat ("verticalSpeed", rb2d.velocity.y);


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
	void Flip()
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

		if (attacking == true)
		{
			attackTrigger.enabled = true;
	
			//Play attack animation
			anim.SetTrigger ("Attack");

		}
		attacking = false;

	}
		

	//When the player is hit by another player
	void DamageCollide()
	{
		//Should call TakeDamage from there
		attackTrigger.enabled = false;
	}

	//Method for when the player is hit by the other
	//Needs to be an IEnumerator because it's a timing thing - it's a coroutine
	//Does this need to be a coroutine though? Investigate
	public IEnumerator playerDamage()
	{
		print ("in playerdamage");
		attackTrigger.enabled = false;

		//Move the player to the 'hurt' layer so the other player can pass through them
		this.gameObject.layer = LayerMask.NameToLayer("HurtPlayer");

		//Add one to number of hits on the other player's UI
		//Will need to be a method to update this after
		hitCounter++;
		print ("Other player has taken damage.");
		anim.SetTrigger ("Damage");

		yield return new WaitForSeconds (damageTime);
		playerControl = true;

		//print ("should move back to layer now!");
		//Move the player back to the player layer
		this.gameObject.layer = LayerMask.NameToLayer("Player");
		//print (this.gameObject.layer.ToString());

	}

	public void TakeDamage()
	{
		print ("takedamage in player called");

		//Give up player control
		playerControl = false;

		//We can't disable the box collider because it'll fall through and we need platforms to be able to act on it
		//So let's make it so it can't collide with the player layer


		StartCoroutine(playerDamage ());
	}

	void Die()
	{
	}
		

	//Delegate stuff!
	void OnEnable()
	{
		GameManager.EndGame += FlipPlayerControl;

	}

	void OnDisable()
	{
		GameManager.EndGame -= FlipPlayerControl;
	}


	//This method should be renamed or edited
	void FlipPlayerControl()
	{
		if (playerControl == true)
		{
			playerControl = false;
			this.rb2d.velocity = Vector3.zero;
			this.rb2d.gravityScale = 0;
		}
		else
		{
			playerControl = true;
			this.rb2d.gravityScale = 3;
		}
			
	}

	void PlayerControlOnOff()
	{
		if (playerControl == true)
		{
			playerControl = false;
		}
		else 
		{
			playerControl = true;
		}
	}

	public void DamageAnim()
	{
//		anim.SetTrigger ("Damage");
	}

	void ResumeControlFromDamage()
	{
		playerControl = true;
	}
		
}