using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvasOnTrigger : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject arrows;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touch detected");
            canvasObject.SetActive(true);
            arrows.SetActive(false);
        }
    }
}
