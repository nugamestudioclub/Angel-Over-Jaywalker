using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Direction {
	Up,
	Down,
	Left,
	Right
}

public class craneButton : MonoBehaviour {
	private Direction direction;
	[SerializeField]
	private float speed = .005f;

	[SerializeField]
	private Transform leftBound;

	[SerializeField]
	private Transform rightBound;

	[SerializeField]
	private Transform upperBound;

	[SerializeField]
	private Transform lowerBound;


	private float LeftBound => leftBound.transform.position.x;

	private float RightBound => rightBound.transform.position.x;

	private float UpperBound => upperBound.transform.position.y;

	private float LowerBound => lowerBound.transform.position.y;


	private GameObject platform;
	private bool touched;

	private PlayerController player;

	// Start is called before the first frame update
	void Start() {
		platform = GameObject.Find("CranePlatform");
		touched = false;
	}

	// Update is called once per frame
	void Update() {
		bool pressed = Input.GetKey(KeyCode.E);

		if( touched && pressed ) {
			if( player != null )
				player.IsBusy = true;

			var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

			Move(input);
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if( IsPlayer(collision.gameObject) ) {
			touched = true;
			player = collision.gameObject.GetComponent<PlayerController>();
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if( IsPlayer(collision.gameObject) ) {
			touched = false;

			if( player != null )
				player.IsBusy = false;

			player = null;
		}
	}

	private bool IsPlayer(GameObject obj) {
		return obj.CompareTag("Player");
	}

	private void Move(Vector2 direction) {
		Vector3 position = platform.transform.position;
		Vector3 delta = Vector3.zero;



		if( direction.x < 0
			&& position.x - speed > LeftBound )
			delta = new Vector3(-speed, delta.y, delta.z);
		else if( direction.x > 0
			&& position.x + speed < RightBound )
			delta = new Vector3(speed, delta.x, delta.z);

		if( direction.y < 0
			&& position.y - speed > LowerBound )
			delta = new Vector3(delta.x, -speed, delta.z);
		else if( direction.y > 0
			&& position.y + speed < UpperBound )
			delta = new Vector3(delta.x, speed, delta.z);

		platform.transform.position += delta;
	}
}
