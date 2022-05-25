using UnityEngine;

[RequireComponent(typeof(BatchRenderer))]
public class Entity : MonoBehaviour {
	private BatchRenderer entityRenderer;

	public Layers.LayerType Layer {
		get => Layers.FromId(gameObject.layer);
		private set => gameObject.layer = Layers.ToId(value);
	}

	[field: SerializeField]
	public Layers.EntityType Type { get; private set; }

	protected virtual void Awake() {
		entityRenderer = GetComponent<BatchRenderer>();
	}
	
	protected virtual void Start() {
		Sort();
	}

	protected virtual void Update() {
	}

	public void MoveLayer(Layers.LayerType layer) {
		Layer = layer;
		Sort();
	}

	private void Sort() {
		entityRenderer.Sort(Layer, Type);
	}
}