using System;
using UnityEngine;

public class Entity : MonoBehaviour {
	private Rigidbody2D body;

	private Collider2D myCollider;

	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Layers.EntityType type;

	[Range(0f, short.MaxValue)]
	private float moveSpeed = 10.0f;

	void Awake() {
		body = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	protected virtual void Start() {
		Sort(Layers.FromId(gameObject.layer));
	}

	public void Move(Vector2 direction) {
		body.velocity = moveSpeed * direction;

	}

	public void Move(Layers.LayerType layer) {
		gameObject.layer = Layers.ToId(layer);
		Sort(layer);
	}

	private void Sort(Layers.LayerType layer) {
		spriteRenderer.sortingLayerID = Layers.SortingLayerId(layer);
		spriteRenderer.sortingOrder = Layers.SortingLayerOrder(type);
	}
}