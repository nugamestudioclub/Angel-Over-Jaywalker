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

		if( Input.GetKeyDown(KeyCode.Space) )
			IsGrounded = !IsGrounded;
	}
}