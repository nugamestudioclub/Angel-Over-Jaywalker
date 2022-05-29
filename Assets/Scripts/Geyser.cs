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
        Renderer rend = GetComponent<Renderer>();

        // if the idle player stays collided with the geyser and the geyser is enabled...
        if (collision.gameObject.CompareTag("IdlePerson") && rend.enabled)
        {
            idleScript person = collision.GetComponent<idleScript>();

            // calculates the depth of the idle player
            float playerHeight = collision.bounds.min.y;
            float geyserHeight = geyserCollider.bounds.max.y;
            float depth = geyserHeight - playerHeight;

            if(depth < .01)
            {
                // decreases speed of idle player
                person.SlowDown();
            }
            else
            {
                // adds upwards force to idle player based on depth
                person.Float(depth);
            }
        }
    }
}
