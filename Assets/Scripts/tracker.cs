using UnityEngine;
public class tracker : MonoBehaviour {
	[SerializeField]
	private GameObject playerObject;

	[SerializeField]
	private GameObject idlePlayerObject;

	[SerializeField]
	private Vector2 horizontalBounds;

	private float baseSize;

	private void Start() {
		baseSize = Camera.main.orthographicSize;
	}

	private float Center => playerObject.transform.position.y
		+ (idlePlayerObject.transform.position.y - playerObject.transform.position.y) / 2;

	void Update() {
		Vector2 playerPos = playerObject.transform.position;
		Vector2 idlePos = idlePlayerObject.transform.position;

		float x = (playerPos.x + idlePos.x) / 2;
		if( Mathf.Abs(playerPos.y - idlePos.y) > Camera.main.orthographicSize * 2 ) {
			x = playerPos.x;
		}

		float halfWidth = Camera.main.orthographicSize * 1.8f;
		if( x - halfWidth < horizontalBounds.x ) // if leftmost point is less than x value of bounds (left bound)... 
		{
			x = horizontalBounds.x + halfWidth; // let x = x value of xBounds
		}
		else if( x + Camera.main.orthographicSize * 1.8 > horizontalBounds.y ) // if rightmost point is greater than y
																			   // value of bounds (right bound)...
		{
			x = horizontalBounds.y - halfWidth; // let x = y value of xBounds
		}

		transform.position = new Vector3(x, Center, -10);

		if( Mathf.Abs(playerPos.x - idlePos.x) > 14 ) {
			Camera.main.orthographicSize = baseSize + 0.77f * (Mathf.Abs(playerPos.x - idlePos.x) - 14) / 2;
		}
	}
}