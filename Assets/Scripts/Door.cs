using UnityEngine;

[RequireComponent(typeof(SwitchRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Door : Entity {
	private Entrance entrance;

	private Exit exit;

	private SwitchRenderer switchRenderer;

	private Collider2D collision;

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
			collision.enabled = !value;
			if( value )
				switchRenderer.SwitchOn();
			else
				switchRenderer.SwitchOff();
		}
	}

	protected override void Awake() {
		base.Awake();

		collision = GetComponent<Collider2D>();
	}

	private void Initialize() {
		entrance = GetComponentInChildren<Entrance>();
		exit = GetComponentInChildren<Exit>();
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