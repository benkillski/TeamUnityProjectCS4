using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnimator;
    float horizontalMove = 0f;
    bool facingRight = true;

    [Header("Movement")]
    [SerializeField] float jumpForce = 400f;
    [SerializeField] float moveSpeed = 5f;
    bool moving;

    [Header("Ground Checking")]
    //[SerializeField] Transform groundCheck;             //Origin for ground check
    [SerializeField] LayerMask groundMask;              //Ground Layer
    public bool isGrounded;
    bool jumping;
    bool canJump;
    Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
        AnimationController();
    }

    void MovementHandler()
    {
        //Jumping Logic
        if (IsGrounded())
        {
            jumping = false;
            canJump = true;
        }
        else
        {
            jumping = true;
            canJump = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded() && canJump)
        {
            jumping = true;
            Jump();
        }

        //Move Left/Right Logic
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (horizontalMove < 0.0f && facingRight)
        {
            Flip();
        }
        else if (horizontalMove > 0.0f && !facingRight)
        {
            Flip();
        }

        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        //Debug.Log("Moving?:" + moving);
        //Debug.DrawLine(transform.position, transform.position - new Vector3(0, GetComponent<SpriteRenderer>().bounds.extents.y + 0.1f, 0), Color.red);
        //Debug.Log("Grounded?: " + isGrounded);
        //Debug.Log("Jumping?: " + jumping);
    }

    private void Jump()
    {
        canJump = false;
        rb.AddForce(new Vector2(0, jumpForce));
        FindObjectOfType<AudioManager>().Play("Player Jump");

    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.CapsuleCast(playerCollider.bounds.center, playerCollider.bounds.size, CapsuleDirection2D.Vertical, 0, Vector2.down, playerCollider.bounds.extents.y, groundMask);
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down, rayColor);
        Debug.Log(hit.collider);

        return hit.collider != null;
    }

    private void AnimationController()
    {
        playerAnimator.SetBool("IsJumping", jumping);
        playerAnimator.SetBool("IsMoving", moving);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy" && isGrounded == false)
        {
            Destroy(collision.gameObject);
        }
    }
}