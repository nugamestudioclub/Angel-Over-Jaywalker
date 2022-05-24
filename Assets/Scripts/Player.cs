using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
	private bool isDown;

	void Update() {
		Move(new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		));

		if( Input.GetKeyDown(KeyCode.E) ) {
			Debug.Log($"current layer id: {gameObject.layer}");
			var layer = isDown
				? Layers.UpFrom(Layers.FromId(gameObject.layer))
				: Layers.DownFrom(Layers.FromId(gameObject.layer));

			Debug.Log($"moving {(isDown ? "up" : "down")} to {layer}");

			isDown = !isDown;
			Move(layer);
		}
	}

	protected override void Start() {
		base.Start();
	}

}