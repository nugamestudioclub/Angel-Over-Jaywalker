using System.Collections.Generic;
using UnityEngine;

public abstract class BatchRenderer : MonoBehaviour {
	private bool visible = true;

	public bool Visible {
		get => visible;
		set {
			visible = value;
			foreach( var renderer in GetAllRenderers() )
				renderer.enabled = value;
		}
	}

	public abstract IEnumerable<Renderer> GetAllRenderers();

	public void Sort(Layers.LayerType layer, Layers.EntityType entity) {
		foreach( var renderer in GetAllRenderers() ) {
			renderer.sortingLayerID = Layers.SortingLayerId(layer);
			renderer.sortingOrder = Layers.SortingLayerOrder(entity);
		}
	}
}