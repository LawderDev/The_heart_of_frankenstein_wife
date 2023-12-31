using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float percentageTension = 0.1f;
    [SerializeField] private int maxJumps = 2; // Nombre maximal de sauts

    [SerializeField] public SpriteRenderer renderer;
    [SerializeField] public Sprite spL, spR, spaccL, spaccR;

    private float  initialColliderSizeY = 0;
    private Vector2 initialColliderOffset;
    private BoxCollider2D playerCollider;
    private PlayerTension playerTension;
    private Rigidbody2D body;
    private int jumpCount = 0;
    private bool ctrlPressed = false;
    private float horizontalInput;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 5;
        playerCollider = GetComponent<BoxCollider2D>();
        playerTension = GetComponent<PlayerTension>();
        initialColliderSizeY = playerCollider.size.y;
        initialColliderOffset = playerCollider.offset;
        renderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        
        moveManagement();
        crouchManagement();
        jumpManagement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           cancelJump();
        }
    }

    
    private void moveManagement(){
        horizontalInput = Input.GetAxis("Horizontal");
        //Flip player when moving left-right

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(transform.localScale.x < 0 ? Mathf.Abs(transform.localScale.x) : transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(transform.localScale.x > 0 ? 0 - transform.localScale.x : transform.localScale.x,transform.localScale.y, transform.localScale.z);

        float factorIncrementation = playerTension.getTension() > 10 ? (playerTension.getTension() * percentageTension) : 1;
        body.velocity = new Vector2(horizontalInput * speed * factorIncrementation, body.velocity.y);
    }

    private void crouchManagement(){
    if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                crouch();
            }
        } 
        else 
        {
            if (ctrlPressed)
            {
                cancelCrouch();
            }
        }
    }

    private void crouch(){
        playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y - initialColliderSizeY / 2f);
        playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y - initialColliderSizeY / 4f);
        renderer.sprite = spaccR;
        ctrlPressed = true;
    }

    private void cancelCrouch(){
        playerCollider.size = new Vector2(playerCollider.size.x, initialColliderSizeY);
        playerCollider.offset = initialColliderOffset;
        renderer.sprite = spR;
        ctrlPressed = false;
    }

    private void jumpManagement(){
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
           jump();
        }
    }

    
    private void jump(){
        body.velocity = new Vector2(body.velocity.x, jumpForce);
         jumpCount++;
    }

    private void cancelJump(){
        jumpCount = 0;
    }
}
