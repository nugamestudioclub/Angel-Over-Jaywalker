using UnityEngine;

public class GeyserActivator : MonoBehaviour {

	private Geyser geyser;

	private bool touched;
	
	private bool activated;

	private SwitchRenderer switchRenderer;

	private AudioSource audioSource;

	private void Awake() {
		switchRenderer = GetComponent<SwitchRenderer>();
	}

	void Start() {
		geyser = GameObject.Find("Geyser").GetComponent<Geyser>();
	}

	void Update() {
		bool pressed = Input.GetKey(KeyCode.E);
		
		if( !activated && touched && pressed )
			Activate();
		else if( activated && !(touched && pressed) )
			Deactivate();
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if( IsPlayer(collision.gameObject) )
        {
			touched = true;
			audioSource.Play();
		}
			
	}

	void OnTriggerExit2D(Collider2D collision) {
		if( IsPlayer(collision.gameObject) )
			touched = false;
	}

	private bool IsPlayer(GameObject obj) {
		return obj.CompareTag("Player");
	}

	private void Activate() {
		activated = true;
		geyser.Activate();
		switchRenderer.SwitchOn();
	}

	private void Deactivate() {
		activated = false;
		geyser.Deactivate();
		switchRenderer.SwitchOff();
	}
}
