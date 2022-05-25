using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserActivator : MonoBehaviour
{
    [SerializeField]
    private float maxHeight;
    private GameObject geyser;
    private bool waterRising = false;
    [SerializeField]
    private float risingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        geyser = GameObject.Find("Geyser");
    }

    // Update is called once per frame
    void Update()
    {
        if (waterRising && geyser.transform.localScale.y < maxHeight)
        {
            Debug.Log("rising");
            geyser.transform.position += new Vector3(0, risingSpeed / 2, 0);
            geyser.transform.localScale += new Vector3(0, risingSpeed, 0);
        } else
        {
            waterRising = false;
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

    public void Activate()
    {
        Debug.Log("activated");
        waterRising = true;
        geyser.GetComponent<Renderer>().enabled = true;
    }
}
