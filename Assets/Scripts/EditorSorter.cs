#if UNITY_EDITOR
using UnityEngine;

public class EditorSorter : MonoBehaviour {
	[SerializeField]
	[SerializeProperty(nameof(LayerType))]
	private LayerType layerType;
	public LayerType LayerType {
		get => layerType;
		set {
			layerType = value;
			Sort();
		}
	}

	[SerializeField]
	[SerializeProperty(nameof(LayerSubtype))]
	private LayerSubtype layerSubtype;
	public LayerSubtype LayerSubtype {
		get => layerSubtype;
		set {
			layerSubtype = value;
			Sort();
		}
	}

	[SerializeField]
	[SerializeProperty(nameof(SortingOrder))]
	private SortingOrder sortingOrder;
	public SortingOrder SortingOrder {
		get => sortingOrder;
		set {
			sortingOrder = value;
			Sort();
		}
	}

	private Layer Layer => new Layer(layerType, layerSubtype);

	private void Sort() {
		if( TryGetComponent(out Door door) )
			SortDoor(door);
		else if( TryGetComponent(out Entity entity) )
			SortEntity(entity);
		else
			SortRenderers();
	}

	private void SortEntity(Entity entity) {
		entity.SortingOrder = sortingOrder;
	}

	private void SortDoor(Door door) {
		SortEntity(door);
		foreach( var transform in door.gameObject.GetComponentsInChildren<Transform>() )
			transform.gameObject.layer = Layer.ToId(Layer);
		foreach( var exit in door.GetComponentsInChildren<Exit>() )
			exit.gameObject.layer = Layer.ToId(Layer.Inside(Layer));
	}

	private void SortRenderers() {
		if( TryGetComponent(out Renderer renderer) )
			renderer.sortingOrder = Layer.SortingOrderId(sortingOrder);
	}
}

#endif