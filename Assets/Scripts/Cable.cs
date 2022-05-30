using UnityEngine;

public class Cable : MonoBehaviour {
	[SerializeField]
	private Transform a;

	[SerializeField]
	private Transform b;

	private float Length => Mathf.Abs(a.position.y - b.position.y);

	private float scale;

	private void Awake() {
		scale = transform.localScale.y / Length;
	}

	private void Update() {
		transform.position = new Vector3(
			transform.position.x,
			a.position.y + (b.position.y - a.position.y) / 2,
			transform.position.z
		);
		transform.localScale = new Vector3(
			1,
			scale * Length,
			1
		);
	}
}