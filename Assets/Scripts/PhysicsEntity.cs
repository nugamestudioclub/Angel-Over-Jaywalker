using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PhysicsEntity : Entity {
	private Rigidbody2D body;

	public Collider2D Collision { get; private set; }

	[Range(0f, short.MaxValue)]
	[SerializeField]
	private float moveSpeed = 10.0f;

	public Vector2 Velocity => body.velocity;

	public bool IsGrounded { get; set; } = true;

	protected override void Awake() {
		base.Awake();

		body = GetComponent<Rigidbody2D>();
		Collision = GetComponent<Collider2D>();
	}

	protected override void Start() {
		base.Start();
	}

	protected override void Update() {
		base.Update();
	}

	public void MoveX(float xDirection) {
		body.velocity = new Vector2(xDirection * moveSpeed, body.velocity.y);
	}

	public void MoveY(float yDirection) {
		body.velocity = new Vector2(body.velocity.x, yDirection * moveSpeed);
	}
}