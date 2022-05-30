using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
	private Collider2D collider2d;
	void Awake() {
		collider2d = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if( collision.TryGetComponent(out idleScript idle) ) {
			idle.Die();
		}
	}

	//editor only
	void OnDrawGizmos() {
		if( collider2d == null ) {
			collider2d = GetComponent<Collider2D>();
		}

		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position, collider2d.bounds.size);
	}
}
