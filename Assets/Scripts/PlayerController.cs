using System;
using UnityEngine;

/*
 * Class for controlling the player's movement
 */
public class PlayerController : MonoBehaviour {
	/*
     * Fields of the player used to manipulate and configure the movement
     */
	[SerializeField]
	private float jumpPower = 6;
	[SerializeField]
	private float moveSpeed = 6;
	private float slowDownRate = 1.1f;
	private Rigidbody2D rigidbody2d;
	private bool isGrounded;
	private bool slowingDown;

	private Animator animator;

	public bool IsBusy { get; set; }

	void Start() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();

		isGrounded = false;
		IsBusy = false;
	}

	void Update() {
		if( Input.GetKeyUp(KeyCode.E) )
			IsBusy = false;

		if( Input.GetKeyDown(KeyCode.Space) && isGrounded ) {
			Jump();
		}
		else if( isGrounded ) {
			rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
		}

		var input = IsBusy ? Vector2.zero
			: new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if( Mathf.Approximately(input.x, 0) )
			slowingDown = true;
		else
			rigidbody2d.velocity = new Vector2(input.x * moveSpeed, rigidbody2d.velocity.y);

		if( slowingDown ) {
			float xVel = rigidbody2d.velocity.x;
			if( Math.Abs(xVel) / slowDownRate < 0.1 ) {
				slowingDown = false;
				rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
			}
			else {
				rigidbody2d.velocity = new Vector2(Math.Sign(xVel) * (Math.Abs(xVel) / slowDownRate), rigidbody2d.velocity.y);
			}
		}

		// this is bad code
		if( Mathf.Approximately(rigidbody2d.velocity.magnitude, 0) )
			animator.Play("guardian_idle");
		else if( !isGrounded )
			animator.Play("guardian_jumping");
		else
			animator.Play("guardian_walking");

	}

	/*
     * Makes the player get a boost of velocity in the y direction
     */
	private void Jump() {
		Vector2 oldVelocity = rigidbody2d.velocity;
		Vector2 newVelocity = new Vector2(oldVelocity.x, jumpPower);
		rigidbody2d.velocity = newVelocity;
	}

	/*
     * Gets called When we stay collided with another collider
     */
	private void OnCollisionStay2D(Collision2D collision) {
		//saving current movement in the y direction
		float yMovement = rigidbody2d.velocity.y;

		//if the player is not moving in the y direction
		if( Mathf.Abs(yMovement) < Mathf.Epsilon ) {
			isGrounded = true; //player is grounded
			slowingDown = false;
		}
	}

	/*
     * Gets called when we stop colliding with another collider
     */
	private void OnCollisionExit2D(Collision2D collision) {
		float yMovement = rigidbody2d.velocity.y;
		if( Mathf.Abs(yMovement) > Mathf.Epsilon ) {
			isGrounded = false;
		}
	}
}
