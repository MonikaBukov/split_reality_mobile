using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAudioTrigger : MonoBehaviour
{
    public AudioClip mushroomClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = mushroomClip;
            audioSource.loop = true;
            audioSource.volume = 0.2f;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.active == false)
        {
            audioSource.Stop();
        }
    }

    void stopAllSounds()
    {
        audioSource.Stop();
    }
}
