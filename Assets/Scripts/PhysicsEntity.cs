using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PhysicsEntity : Entity {
	private Rigidbody2D body;

	private float gravityScale;

	public Collider2D Collider { get; private set; }

	[Range(0f, short.MaxValue)]
	[SerializeField]
	private float moveSpeed = 10.0f;

	public Vector2 Velocity => body.velocity;

	[ReadOnly]
	[SerializeField]
	private bool isGrounded = true;
	public bool IsGrounded {
		get => isGrounded;
		set {
			isGrounded = value;
			//body.gravityScale = value ? 0 : gravityScale;
		}
	}

	protected override void Awake() {
		base.Awake();

		body = GetComponent<Rigidbody2D>();
		Collider = GetComponent<Collider2D>();

		gravityScale = body.gravityScale;
	}

	protected override void Start() {
		base.Start();

		IsGrounded = isGrounded;
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

	public void Jump(float force) {
		body.AddForce(new Vector2(0, force));
	}
}