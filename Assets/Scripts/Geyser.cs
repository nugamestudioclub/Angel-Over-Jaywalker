using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    private Collider2D geyserCollider;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;

        geyserCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("IdlePerson"))
        {
            idleScript person = collision.GetComponent<idleScript>();

            float playerHeight = collision.bounds.min.y;
            float geyserHeight = geyserCollider.bounds.max.y;
            float depth = geyserHeight - playerHeight;

            if(depth < .01)
            {
                person.SlowDown();
            }
            else
            {
                person.Float(depth);
            }
        }
    }
}
