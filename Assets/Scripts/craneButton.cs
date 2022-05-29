using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class craneButton : MonoBehaviour
{
    private Direction direction;
    [SerializeField]
    private float speed = .005f;

    private GameObject[] xBoundObjects;
    private GameObject[] yBoundObjects;
    private float[] boundXCoords;
    private float[] boundYCoords;
    private float leftBound;
    private float rightBound;
    private float upperBound;
    private float lowerBound;

    private GameObject platform;
    private bool isControlling;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.Find("CranePlatform");
        isControlling = false;

        // finds the left and right bounds based on min and max x positions of CranePlatformXBound GameObjects
        xBoundObjects = GameObject.FindGameObjectsWithTag("CranePlatformXBound");
        IEnumerable<float> listX = xBoundObjects.Select(GameObject => GameObject.transform.position.x);
        boundXCoords = listX.ToArray();
        leftBound = boundXCoords.Min();
        rightBound = boundXCoords.Max();

        // fins the upper and lower bounds based on min and max y positions of CranePlatformYBound GameObjects
        yBoundObjects = GameObject.FindGameObjectsWithTag("CranePlatformYBound");
        IEnumerable<float> listY = yBoundObjects.Select(GameObject => GameObject.transform.position.y);
        boundYCoords = listY.ToArray();
        upperBound = boundYCoords.Max();
        lowerBound = boundYCoords.Min();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isControlling)
        {
            direction = Direction.Left;
            Move();
        }

        if (Input.GetKey(KeyCode.RightArrow) && isControlling)
        {
            direction = Direction.Right;
            Move();
        }

        if (Input.GetKey(KeyCode.UpArrow) && isControlling)
        {
            direction = Direction.Up;
            Move();
        }

        if (Input.GetKey(KeyCode.DownArrow) && isControlling)
        {
            direction = Direction.Down;
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Controlling");
            isControlling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stopped controlling");
            isControlling = false;
        }
    }

    private void Move()
    {
        Vector3 position = platform.transform.position;

        switch (direction)
        {
            case Direction.Up:
                Debug.Log("up");
                // if the platform is lower than the upper bound, move it up
                if (position.y + platform.transform.localScale.y / 2 < upperBound)
                {
                    platform.transform.position += new Vector3(0, speed, 0);
                } else
                {
                    Debug.Log("Hit upper bound");
                }
                break;
            case Direction.Down:
                Debug.Log("down");
                // if the platform is above the lower bound, move it down
                if (position.y - platform.transform.localScale.y / 2 > lowerBound)
                {
                    platform.transform.position += new Vector3(0, -speed, 0);
                } else
                {
                    Debug.Log("Hit lower bound");
                }
                break;
            case Direction.Left:
                Debug.Log("left");
                // if the platform is farther right than the left bound, move it left
                if (position.x - platform.transform.localScale.x / 2 > leftBound)
                {
                    platform.transform.position += new Vector3(-speed, 0, 0);
                }
                else
                {
                    Debug.Log("Hit left bound");
                }
                break;
            case Direction.Right:
                Debug.Log("right");
                // if the platform is farther left than the right bound, move it right
                if (position.x + platform.transform.localScale.x / 2 < rightBound)
                {
                    platform.transform.position += new Vector3(speed, 0, 0);
                }
                else
                {
                    Debug.Log("Hit right bound");
                }
                break;
        }
    }
}
