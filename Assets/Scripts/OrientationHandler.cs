using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class OrientationHandler : MonoBehaviour
{
    public GameObject portraitObject;
    public GameObject landscapeObject;
    private Camera mainCamera;
    public float cameraSizePortrait = 10f;
    public float cameraSizeLandscape = 15f;
    private ScreenOrientation previousOrientation;
    public AudioClip dayClip;
    public AudioClip nightClip;
    public AudioClip menuClip;
    public AudioSource audioSource;
    public GameObject StartScreen;
    public bool inGame = false;

    void Start()
    {
        mainCamera = Camera.main;
        previousOrientation = Screen.orientation;
        PlaySoundEffectMenuClip();

        // Determine current screen orientation and enable/disable objects accordingly
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            portraitObject.SetActive(true);
            landscapeObject.SetActive(false);
            mainCamera.orthographicSize = cameraSizePortrait;
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            portraitObject.SetActive(false);
            landscapeObject.SetActive(true);
            mainCamera.orthographicSize = cameraSizeLandscape;
        }
    }

    private void Update()
    {
       
        
        if (Screen.orientation != previousOrientation)
        {
            previousOrientation = Screen.orientation;

            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                portraitObject.SetActive(true);
                landscapeObject.SetActive(false);
                mainCamera.orthographicSize = cameraSizePortrait;
                PlaySoundEffectDayClip();
            }
            else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            {
                portraitObject.SetActive(false);
                landscapeObject.SetActive(true);
                mainCamera.orthographicSize = cameraSizeLandscape;
                PlaySoundEffectNightClip();
            }
        }
    }
    public void PlaySoundEffectDayClip()
    {
        audioSource.clip = dayClip;
        audioSource.pitch = 3;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlaySoundEffectNightClip()
    {
        audioSource.clip = nightClip;
        audioSource.pitch = 2;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlaySoundEffectMenuClip()
    {
        audioSource.Stop();
        audioSource.clip = menuClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void StopSoundEffectMenuClip()
    {
        audioSource.clip = menuClip;
        audioSource.Stop();
        audioSource.clip = dayClip;
        audioSource.loop = false;
        audioSource.Play();
    }
}