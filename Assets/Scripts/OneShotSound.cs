using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private float lifespan;
    private bool playing;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (lifespan < 0)
            {
                Destroy(this);
            }
            lifespan -= Time.deltaTime;
        }
    }

    public void Play(AudioClip audio)
    {
        if (audio != null)
        {
            playing = true;
            lifespan = audio.length;
            audioSource.PlayOneShot(audio);
        }
    }
}
