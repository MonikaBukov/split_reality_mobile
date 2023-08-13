using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvasObject;
    private ScreenOrientation originalOrientation;
    private bool canvasActive = false;
    public float displayTime = 10.0f;
    public AudioClip menuClip;
    public AudioClip dayClip;
    public AudioSource audioSource;

    void Start()
    {
        originalOrientation = Screen.orientation;
        PlaySoundEffectMenuClip();
    }

    void Update()
    {
        if (Screen.orientation != originalOrientation && !canvasActive)
        {
            canvasObject.SetActive(true);
            Invoke("DisableCanvas", displayTime);
            canvasActive = true;
            StopSoundEffectMenuClip();
        }
    }

    void DisableCanvas()
    {
        canvasObject.SetActive(false);
        canvasActive = false;
    }

    public void StopSoundEffectMenuClip()
    {
        audioSource.Stop();
        audioSource.clip = dayClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySoundEffectMenuClip()
    {
        audioSource.Stop();
        audioSource.clip = menuClip;
        audioSource.loop = false;
        audioSource.Play();
    }
}



