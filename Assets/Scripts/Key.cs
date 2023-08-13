using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isHeld = false;
    public GameObject newKey;
    public GameObject oldItem;
    public AudioSource heldTorchSFX;
    public AudioSource keyPickup;
    public AudioClip keyPickupSFX;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isHeld = true;
            heldTorchSFX.Stop();
            keyPickup.clip = keyPickupSFX;
            keyPickup.loop = false;
            keyPickup.Play();
            gameObject.SetActive(false);
            oldItem.SetActive(false);
            newKey.SetActive(true);

        }
    }
}
