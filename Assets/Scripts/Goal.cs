using UnityEngine;

public class Goal : MonoBehaviour
{
    private Collider2D collider2d;
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out idleScript idle)) {
            idle.Goal();
        }
    }

    //editor only
    void OnDrawGizmos()
    {
        if (collider2d == null)
        {
            collider2d = GetComponent<Collider2D>();
        }

        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, collider2d.bounds.size);
    }
}
