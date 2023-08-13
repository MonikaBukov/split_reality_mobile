using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isHeld = false;
    public GameObject newTorch;
    public AudioSource pickupSFX;
    public AudioSource heldTorchSFX;
    public AudioClip pickupClip;
    public AudioClip heldTorchClip;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickupSFX.clip = pickupClip;
            pickupSFX.Play();
            heldTorchSFX.clip = heldTorchClip;
            heldTorchSFX.loop = true;
            heldTorchSFX.Play();
            isHeld = true;
            gameObject.SetActive(false);
            newTorch.SetActive(true); 
        }
    }
}

