using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvasOnTouch : MonoBehaviour
{
    private float lastTapTime;
    public AudioClip dayClip;
    public AudioSource audioSource;
    private void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2)
        {
            if (Time.time - lastTapTime < 0.5f)
            {
                audioSource.Stop();
                //audioSource.clip = dayClip;
                //audioSource.loop = true;
               // audioSource.Play();
                gameObject.SetActive(false);
                
            }
            lastTapTime = Time.time;
        }
    }
}
