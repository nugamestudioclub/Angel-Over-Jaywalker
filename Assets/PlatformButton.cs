using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{

    public GameObject Platform;
    public GameObject LeftTarget;
    public GameObject RightTarget;
    private bool atLeft = true;
    [SerializeField] float step;

    // Start is called before the first frame update
    void Start()
    {
        Platform.transform.position = RightTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (atLeft)
        {
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, RightTarget.transform.position, step);
        }


        if (!atLeft)
        {
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, LeftTarget.transform.position, step);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        atLeft = !atLeft;
        
        
    }
}
