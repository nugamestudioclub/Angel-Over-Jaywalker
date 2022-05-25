using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsEntity {
	private bool isDown;

	[SerializeField]
	private float jumpPower = 5.0f;


	protected override void Awake() {
		base.Awake();
	}

	protected override void Start() {
		base.Start();
	}

	protected override void Update() {
		base.Update();

		if( IsGrounded ) {
			float x = Input.GetAxis("Horizontal");
			float y = Input.GetAxis("Vertical");

			MoveX(x);
			MoveY(y);
		}
		else {
			MoveX(Velocity.x / 10);
		}

		if( Input.GetKeyDown(KeyCode.Space) )
			Jump(jumpPower);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
	}
}