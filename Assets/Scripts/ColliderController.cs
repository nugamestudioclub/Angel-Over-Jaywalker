using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class ColliderController : MonoBehaviour
{
    [HideInInspector]
    public bool isColliding = false;

    [SerializeField]
    private string myTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (string.IsNullOrEmpty(myTag))
        {
            isColliding = true;
        }
        else
        {
            if (myTag == collision.gameObject.tag)
            {
                isColliding = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (string.IsNullOrEmpty(myTag))
        {
            isColliding = false;
        }
        else
        {
            if (myTag == collision.gameObject.tag)
            {
                isColliding = false;
            }
        }

    }
}
