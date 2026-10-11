using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float movement = 0;
    private bool isMoving = false;
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

    void Update()
    {
        isMoving = (movement != 0);
        animator.SetBool("Run", isMoving);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

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
