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

    private ColliderController colliderController;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        colliderController = GetComponentInChildren<ColliderController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colliderController.isColliding) //stuck
        {
            speed = -speed;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
    }

    public void Float(float depth)
    {
        // adds upwards force to the idle player based on water depth
        float upwardsForce = (9.81f + depth) * buoyancy;
        rigidbody2d.AddForce(new Vector2(0, upwardsForce));
    }

    public void SlowDown()
    {
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
        SceneLoader.WinGame();
    }


}
