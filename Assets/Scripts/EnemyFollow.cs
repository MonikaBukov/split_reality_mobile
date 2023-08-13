using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 2f;
    public float stoppingDistance = 0.5f;
    private SpriteRenderer spriteRenderer;
    public Animator anim;
    public Torch torch;
    public Transform respawnPoint;
    public GameObject player;
    private bool playerCollided = false;
    private float respawnDelay = 1f; // 2 seconds delay before respawning


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > stoppingDistance)
        {
            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            anim.SetBool("Player_Is_Close", true);

            // Flip the sprite based on the player's position
            if (playerTransform.position.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            // Hide or show the enemy based on whether the player is holding the torch
            if (torch.isHeld)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            // Play the collision animation and respawn the player after a delay
            if (!playerCollided)
            {
                playerCollided = true;
                anim.SetBool("Collided_With_Player", true);
                Invoke("RespawnPlayer", respawnDelay);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = null;
            anim.SetBool("Player_Is_Close", false);
        }
    }


    private void RespawnPlayer()
    {
        // Reset the animation and respawn the player
        anim.SetBool("Collided_With_Player", false);
        player.transform.position = respawnPoint.position;
        playerCollided = false;
    }
}
