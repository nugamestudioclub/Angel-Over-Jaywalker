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
		if( collider.TryGetComponent(out PhysicsEntity entity)
			&& entity.Layer.type != Layer.type ) {
			entity.IsGrounded = true;
			entity.MoveLayer(new Layer(Layer.type, entity.Layer.subtype));
		}
		
	}

	void OnTriggerExit2D(Collider2D collider) {
		if( collider.TryGetComponent(out PhysicsEntity entity) )
			entity.IsGrounded = false;
	}
}
