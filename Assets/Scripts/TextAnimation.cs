using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines = new string[10];
    public AudioClip mushroomChatter;
    public AudioSource mushroomTalk;

    int currentIndex = 0;
    bool isAnimating = false;

    void Start()
    {
        StartCoroutine(AnimateText(dialogueLines[currentIndex]));
        mushroomTalk.clip = mushroomChatter;
        mushroomTalk.loop = true;
    }

    void Update()
    {
        if (!isAnimating && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            currentIndex++;
            if (currentIndex < dialogueLines.Length)
            {
                
                StartCoroutine(AnimateText(dialogueLines[currentIndex]));
            }
        }
    }

    IEnumerator AnimateText(string text)
    {
        isAnimating = true;
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;

            // Adjust this value to change the speed of the animation
            yield return new WaitForSeconds(0.05f); 
            if (isAnimating == true && !mushroomTalk.isPlaying)
            {
                mushroomTalk.loop = true;
                mushroomTalk.Play();
            }
        }
        isAnimating = false;
        mushroomTalk.loop = false;
    }
}

