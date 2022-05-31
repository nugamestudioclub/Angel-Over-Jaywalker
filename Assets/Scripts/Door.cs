using UnityEngine;

[RequireComponent(typeof(SwitchRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Door : Entity {
	private Entrance entrance;

	private Exit exit;

	private SwitchRenderer switchRenderer;

	private Collider2D Collider { get; set; }

	[SerializeField]
	[SerializeProperty(nameof(IsOpen))]
	private bool isOpen;
	public bool IsOpen {
		get => isOpen;
		set {
#if UNITY_EDITOR
			Initialize();
#endif
			isOpen = value;
			entrance.IsOpen = value;
			exit.IsOpen = value;
			Collider.enabled = !value;
			if( value )
				switchRenderer.SwitchOn();
			else
				switchRenderer.SwitchOff();
		}
	}

	protected override void Awake() {
		base.Awake();

		Initialize();
	}

	private void Initialize() {
		entrance = GetComponentInChildren<Entrance>();
		exit = GetComponentInChildren<Exit>();
		Collider = GetComponent<Collider2D>();
		switchRenderer = GetComponent<SwitchRenderer>();
	}

	protected override void Start() {
		base.Start();

		IsOpen = isOpen;
	}

	protected override void Update() {
		base.Update();
	}

	public void Open() {
		IsOpen = true;
	}

	public void Close() {
		IsOpen = false;
	}
}