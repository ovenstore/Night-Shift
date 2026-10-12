using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float movement = 0;
    private bool isGrounded;

    private Animator animator;
    private Rigidbody2D rb;

    public int moveSpeed;
    public int jumpVelocity;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // update the animator depending on whether the player is moving
        animator.SetBool("Run", movement != 0);

        // move the player
        rb.linearVelocity = new Vector2(movement * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player is on the ground, set the isGrounded boolean
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    // player movement functions 

    void OnMove(InputValue value) {
        movement = value.Get<float>();
    }

    void OnJump() {
        if (isGrounded)
        {
            animator.SetTrigger("Jump");
            rb.linearVelocityY = jumpVelocity;

            isGrounded = false;
        }
    }

    void OnHighAttack()
    {
        animator.SetTrigger("High Attack");
    }

    void OnLowAttack() {
        animator.SetTrigger("Low Attack");
    }
}
