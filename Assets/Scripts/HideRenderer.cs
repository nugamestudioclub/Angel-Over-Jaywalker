using UnityEngine;

public class HideRenderer : MonoBehaviour {
	void Start() {
		var renderer = GetComponent<Renderer>();
		renderer.enabled = false;
	}
}