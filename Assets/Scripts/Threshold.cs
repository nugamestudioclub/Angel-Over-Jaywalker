using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Threshold : MonoBehaviour {
	public bool IsOpen { get; set; }
	public Layers.LayerType Layer => Layers.FromId(gameObject.layer);

	protected Collider2D Collision { get; private set; }

	void Awake() {
		Collision = GetComponent<Collider2D>();
	}

	protected float HeightOf(Collider2D collider) {
		return collider.bounds.center.y;
	}

	void OnTriggerExit2D(Collider2D collision) {
		if( IsOpen && collision.gameObject.TryGetComponent(out PhysicsEntity entity) )
			HandleExit(entity);
	}

	protected abstract void HandleExit(PhysicsEntity entity);
}