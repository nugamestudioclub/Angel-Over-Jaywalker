using System;
using UnityEngine;

public class Entity : MonoBehaviour {
	private Rigidbody2D body;

	private Collider2D myCollider;

	private SpriteRenderer spriteRenderer;

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

	public void Move(Layers.Type layer) {
		gameObject.layer = Layers.ToId(layer);
		Sort(layer);
	}

	private void Sort(Layers.Type layer) {
		Debug.Log($"current sorting layer: {spriteRenderer.sortingLayerID}");
		Debug.Log($"changing to layer: {Layers.SortingLayerId(layer, Layers.Subtype.Static)}");
		spriteRenderer.sortingLayerID = Layers.SortingLayerId(layer, Layers.Subtype.Dynamic);
		Debug.Log($"new sorting layer: {spriteRenderer.sortingLayerID}");
	}
}