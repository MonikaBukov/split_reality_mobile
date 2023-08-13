using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator anim;
    public Key key;
    public BoxCollider2D myBoxCollider;
    public AudioSource BGM;

    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Open_Gate"))
        {
            Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && key.isHeld)
        {
            anim.SetBool("Player_Close", true);
            anim.SetBool("Has_Key", true);
            BGM.Stop();

        }
    }
}
