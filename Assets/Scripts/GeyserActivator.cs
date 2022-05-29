using UnityEngine;

public class GeyserActivator : MonoBehaviour
{
    [SerializeField]
    private float maxHeight;
    private GameObject geyser;
    private bool activated = false;
    [SerializeField]
    private float risingSpeed = .06f;

    // Start is called before the first frame update
    void Start()
    {
        geyser = GameObject.Find("Geyser");
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && geyser.transform.localScale.y < maxHeight)
        {
            Debug.Log("rising");
            geyser.transform.position += new Vector3(0, risingSpeed / 2, 0);
            geyser.transform.localScale += new Vector3(0, risingSpeed, 0);
        }
        if (!activated && geyser.transform.localScale.y > Mathf.Epsilon)
        {
            Debug.Log("falling");
            geyser.transform.position += new Vector3(0, -risingSpeed / 2, 0);
            geyser.transform.localScale += new Vector3(0, -risingSpeed, 0);
        } else if (!activated)
        {
            geyser.GetComponent<Renderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Activator pressed");
            Activate();
        }
    }

    private void Activate()
    {
        Debug.Log("activated");
        activated = !activated;
        geyser.GetComponent<Renderer>().enabled = true;
    }
}
