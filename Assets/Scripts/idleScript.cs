using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleScript : MonoBehaviour
{

    [SerializeField]
    private int speed;
    [SerializeField]
    private float buoyancy;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
    }

    public void Float(float depth)
    {
        Debug.Log("Floating");
        float upwardsForce = (9.81f + depth) * buoyancy;
        rigidbody2d.AddForce(new Vector2(0, upwardsForce));
    }

    public void SlowDown()
    {
        Debug.Log("slowing down");
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y * 2 / 5);
    }
}
