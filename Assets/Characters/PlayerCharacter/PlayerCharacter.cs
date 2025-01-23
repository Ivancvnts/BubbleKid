using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    [Header("Jump System")]
    [SerializeField] float jumpTime;
    [SerializeField] float velocity;
    [SerializeField] int jumpPower;
    [SerializeField] float jumpMultiplayer;
    [SerializeField] float fallMultiplayer;

    public GameManager gameManager;
    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;
    
    private Rigidbody2D rb;
    private Animator animator;
    private bool isDead;

    bool isJumping;
    float jumpCounter;
    bool isFacingRight = true;
    float horizontalInput;
    bool isOnBubble;
    Vector2 bubbleMovementDirection;

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Movimiento horizontal
        horizontalInput = Input.GetAxis("Horizontal");

        if (isOnBubble)
        {
            Vector2 bubbleInfluence = bubbleMovementDirection;
            Vector2 playerMovement = new Vector2(horizontalInput * velocity, rb.velocity.y);

            // Aplicamos el movimiento de la burbuja solo en horizontal
            rb.velocity = new Vector2(playerMovement.x + bubbleInfluence.x, playerMovement.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontalInput * velocity, rb.velocity.y);
        }

        flip();
         

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            animator.SetBool("isJumping", isJumping);   
            jumpCounter = 0;
            Debug.Log("Jumping");          
        }

        if(rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime)
            {
                isJumping = false;
                animator.SetBool("isJumping", isJumping);
            }

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplayer;
            if(t > 0.5f)
            {
                currentJumpM = jumpMultiplayer * (1 - t);
            }

            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
            
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
            jumpCounter = 0;
            
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        //Caida
        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplayer * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spike") && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            isOnBubble = true; // El jugador está sobre la burbuja
            bubbleMovementDirection = collision.gameObject.GetComponent<Bubble>().GetMovementDirection(); // Obtener dirección de movimiento de la burbuja
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnBubble = false;
    }

    private void flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.02f, 0.05f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    public void setIsOnBubble(bool isOnBubble)
    {
        if (isOnBubble)
        {
            velocity *= 1.6f;
        }
        else
        {
            velocity /= 1.6f;
        }
        
    }

}
