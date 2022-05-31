using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParentRenderer : BatchRenderer {
	private readonly List<Renderer> renderers = new List<Renderer>();

	void Awake() {
		Initialize();
	}

	public override IEnumerable<Renderer> AllRenderers() {
#if UNITY_EDITOR
		Initialize();
#endif
		return renderers;
	}

	private void Initialize() {
		renderers.AddRange(GetComponentsInChildren<Renderer>());
	}
}