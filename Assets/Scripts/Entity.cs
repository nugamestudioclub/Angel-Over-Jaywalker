using UnityEngine;

[RequireComponent(typeof(BatchRenderer))]
public class Entity : MonoBehaviour {
	private BatchRenderer batchRenderer;

	public Layer Layer {
		get => Layer.FromId(gameObject.layer);
		private set => gameObject.layer = Layer.ToId(value);
	}

	[SerializeField]
	private SortingOrder sortingOrder;

	public SortingOrder SortingOrder {
		get => sortingOrder;
		set {
			sortingOrder = value;
#if UNITY_EDITOR
			Initialize();
#endif
			Sort();
		}
	}

	private void Initialize() {
		batchRenderer = GetComponent<BatchRenderer>();
	}

	protected virtual void Awake() {
		Initialize();
	}

	protected virtual void Start() {
		Sort();
	}

	protected virtual void Update() {
	}

	public void MoveLayer(Layer layer) {
		Layer = layer;
		Sort();
	}

	private void Sort() {
		batchRenderer.Sort(Layer, SortingOrder);
	}
}