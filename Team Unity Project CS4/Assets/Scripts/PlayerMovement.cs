using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnimator;
    float horizontalMove = 0f;
    bool facingRight = true;

    [Header("Movement")]
    [SerializeField] float jumpForce = 300f;
    [SerializeField] float moveSpeed = 5f;
    bool moving;

    [Header("Ground Checking")]
    [SerializeField] Transform groundCheck;             //Origin for ground check
    [SerializeField] LayerMask groundMask;              //Ground Layer
    public bool isGrounded;
    bool jumping;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, GetComponent<SpriteRenderer>().bounds.extents.y + 0.1f, groundMask);
        if (isGrounded)
        {
            jumping = false;
            canJump = true;
        }
        else
        {
            jumping = true;
            canJump = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && canJump)
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
        Debug.Log("Jumping?: " + jumping);
    }

    private void Jump()
    {
        canJump = false;
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
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