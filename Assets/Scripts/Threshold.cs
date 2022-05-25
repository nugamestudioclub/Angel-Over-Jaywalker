using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Threshold : MonoBehaviour {
	public bool IsOpen { get; set; }

	public Layer Layer => Layer.FromId(gameObject.layer);

	protected Collider2D Collider { get; private set; }

	void Awake() {
		Collider = GetComponent<Collider2D>();
	}

	protected float HeightOf(Collider2D collider) {
		return collider.bounds.center.y;
	}

	void OnTriggerExit2D(Collider2D collider) {
		if( IsOpen && collider.gameObject.TryGetComponent(out PhysicsEntity entity) )
			HandleExit(entity);
	}

	protected abstract void HandleExit(PhysicsEntity entity);
}