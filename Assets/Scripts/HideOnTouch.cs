using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HideOnTouch : MonoBehaviour
{
    // Reference to the image you want to hide
    public Image imageToHide;
    public TextMeshProUGUI textToHide;
    public AudioSource startSound;
    public AudioSource audioSource;
    public AudioClip menuClip;
    public AudioClip startClip;
    public AudioClip dayClip;
    public bool startPressed = false;

    void Update()
    {
        // Check if the screen has been touched
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on the image
            if (RectTransformUtility.RectangleContainsScreenPoint(imageToHide.rectTransform, touch.position))
                {
                    if (startPressed == false)
                    {
                        startSound.clip = startClip;
                        startSound.Play();
                        audioSource.Stop();
                        startPressed = true;
                        imageToHide.enabled = false;
                        textToHide.enabled = false;
                    }
                    else
                    {
                        imageToHide.enabled = false;
                        textToHide.enabled = false;
                    }
                }
        }
    }
}

