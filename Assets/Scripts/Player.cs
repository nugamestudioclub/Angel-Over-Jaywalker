using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsEntity {
	private bool isDown;

	protected override void Awake() {
		base.Awake();
	}

	protected override void Start() {
		base.Start();
	}

	protected override void Update() {
		base.Update();

		if( IsGrounded ) {
			MoveX(Input.GetAxis("Horizontal"));
			MoveY(Input.GetAxis("Vertical"));
		}
		else {
			MoveX(Velocity.x / 10);
		}

		if( Input.GetKeyDown(KeyCode.Space) )
			IsGrounded = !IsGrounded;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
	}
}