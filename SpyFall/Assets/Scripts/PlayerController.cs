using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
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

	bool doubleJump = false;



	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () 
	{
		//Change this to name rather than code
		if ((grounded || !doubleJump) && Input.GetButtonDown (jumpButton)) 
		{
			anim.SetBool ("Ground", false);
			rb2d.AddForce(new Vector2(0, jumpForce));

			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void FixedUpdate()
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
		print (grounded);
	}

	void Flip()
	{
		facingRight = !facingRight;
		//Vector3 Scale = transform.localScale;
		//Scale.x *= -1;
		//transform.localScale = Scale;
		anim.transform.Rotate(0,180,0);
	}

	void Attack()
	{
	}

	void GetHurt()
	{
	}

	void Die()
	{
	}
		



}