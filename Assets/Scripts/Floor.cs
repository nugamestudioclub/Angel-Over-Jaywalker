using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	[SerializeField]
	private LayerType layerType;

	public Layer Layer {
		get => new Layer(layerType);
		set {
			layerType = value.type;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log(collider.gameObject.name + " is entering...");
		if( collider.TryGetComponent(out PhysicsEntity entity)
			&& entity.Layer.type != Layer.type ) {
			entity.IsGrounded = true;
			entity.MoveLayer(new Layer(Layer.type, entity.Layer.subtype));
		}
		
	}

	void OnTriggerExit2D(Collider2D collider) {
		Debug.Log(collider.gameObject.name + " is exiting...");
		if( collider.TryGetComponent(out PhysicsEntity entity) )
			entity.IsGrounded = false;
	}
}
