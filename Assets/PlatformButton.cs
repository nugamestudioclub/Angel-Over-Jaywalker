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
    [SerializeField]
    private Sprite pressed;
    [SerializeField]
    private Sprite unpressed;
    private AudioSource audioSource;
    private SpriteRenderer spriteRennderer;
    

    void Awake()
    {
        Platform.transform.position = RightTarget.transform.position;
        audioSource = GetComponent<AudioSource>();
        spriteRennderer = GetComponent<SpriteRenderer>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        atLeft = !atLeft;

        audioSource.Play();
        spriteRennderer.sprite = pressed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRennderer.sprite = unpressed;
    }
}
