using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{
    public GameObject torchPrefab;
    private GameObject torchGameObject = null;

    public GameObject keyPrefab;
    private GameObject keyGameObject = null;

    public Rigidbody2D rb;
    public Vector2 movement;
    bool facingRight = true;
    public Animator anim;
    public int speed = 5;
    public bool torchHeld = false;
    public bool playerMoving = false;
    public AudioSource playerStep;
    public AudioClip playerStepSFX;

    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStep.clip = playerStepSFX;
        playerStep.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Get input for movement
        Orientation();
        if (torchGameObject != null)
        {
            torchGameObject.transform.position = transform.position + transform.right * 0.5f;
            torchGameObject.transform.rotation = transform.rotation;
            
        }
  
        if (keyGameObject != null)
        {
            keyGameObject.transform.position = transform.position + transform.right * 0.5f;
            torchGameObject.transform.rotation = transform.rotation;
        }


    }
    
    void FixedUpdate()
    {
        ButtonMove();
        if (playerMoving == true && !playerStep.isPlaying)
        {
            playerStep.Play();
        }
        else
        {
            playerStep.Stop();
        }
    }

    public void ButtonMove()
    {
        float horizontalInput = SimpleInput.GetAxisRaw("Horizontal");
        float verticalInput = SimpleInput.GetAxisRaw("Vertical");

        // Normalize the input vector so that diagonal movement isn't faster
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;

        // Set the animator's speed parameter based on movementInput magnitude
        anim.SetFloat("Speed", movementInput.magnitude);

        // Move the player using the Rigidbody2D component's MovePosition method
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            playerMoving = true;
            if (horizontalInput > 0 && !facingRight)
            {
                Flip();
            }
            else if (horizontalInput < 0 && facingRight)
            {
                Flip();
            }
        }
        else if (horizontalInput == 0 && verticalInput == 0)
        {
            playerMoving = false;
        }
    }

    // Fliping the texture
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x = -currentScale.x;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    void Orientation()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            anim.SetBool("Night", false);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            anim.SetBool("Night", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torch"))
        {
            anim.SetBool("Has_Torch", true);
           
        }
    }
}