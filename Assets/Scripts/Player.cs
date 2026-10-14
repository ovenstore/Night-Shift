using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float movement = 0;
    private bool isGrounded;

    private Animator animator;
    private Rigidbody2D rb;

    public int moveSpeed;
    public int jumpVelocity;
    public Collider2D broomCollider;
    public Slider healthBar;
    public bool highAttacking = false;
    public bool lowAttacking = false;
    public float health;
    private float currentHealth;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // disable the broom collider so that it is only enabled when attacking
        broomCollider.enabled = false;

        // set up the health bar
        healthBar.maxValue = health;
        healthBar.value = health;
        currentHealth = health;
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

    // take damage if in contact wiht an enemy
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 0.1f;
            healthBar.value = currentHealth;
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
        broomCollider.enabled = true;
        highAttacking = true;
    }

    void OnLowAttack() {
        animator.SetTrigger("Low Attack");
        broomCollider.enabled = true;
        lowAttacking = true;
    }

    // called from the animator at the end of the attacking animations
    void StopAttack()
    {
        broomCollider.enabled = false;
        highAttacking = false;
        lowAttacking = false;
    }
}
