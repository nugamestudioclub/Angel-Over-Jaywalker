using UnityEngine;

public class idleScript : MonoBehaviour
{

    [SerializeField]
    private int speed = 1;
    [SerializeField]
    private float buoyancy = 3f;
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private AudioClip goalClip;

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
        // adds upwards force to the idle player based on water depth
        float upwardsForce = (9.81f + depth) * buoyancy;
        rigidbody2d.AddForce(new Vector2(0, upwardsForce));
    }

    public void SlowDown()
    {
        Debug.Log("slowing down");
        // slows speed of idle player once exiting water
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y * 2 / 5);
    }

    public void Die()
    {
        SceneLoader.Instance.PlayGlobalClip(deathClip);
        SceneLoader.LoadCurrentPuzzle();
    }

    public void Goal()
    {
        SceneLoader.Instance.PlayGlobalClip(goalClip);
        SceneLoader.LoadNextPuzzle();
    }
}
