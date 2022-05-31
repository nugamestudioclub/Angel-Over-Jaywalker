using System.Collections.Generic;
using UnityEngine;

public abstract class BatchRenderer : MonoBehaviour {
	private bool visible = true;

	public bool Visible {
		get => visible;
		set {
			visible = value;
			foreach( var renderer in AllRenderers() )
				renderer.enabled = value; 
		}
	}

	public abstract IEnumerable<Renderer> AllRenderers();

	public void Sort(Layer layer, SortingOrder entity) {
		foreach( var renderer in AllRenderers() ) {
			renderer.sortingLayerID = Layer.SortingLayerId(layer);
			renderer.sortingOrder = Layer.SortingOrderId(entity);
		}
	}
}