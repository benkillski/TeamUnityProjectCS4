using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float horizontalMove = 0f;
    bool facingRight = true;

    [Header("Forces/Speeds")]
    [SerializeField] float jumpForce = 300f;
    [SerializeField] float moveSpeed = 5f;

    [Header("Ground Checking")]
    [SerializeField] Transform groundCheck;             //Origin for ground check
    [SerializeField] LayerMask groundMask;              //Ground Layer
    bool isGrounded;
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, GetComponent<SpriteRenderer>().bounds.extents.y + 0.1f, groundMask);
        //Debug.DrawLine(transform.position, transform.position - new Vector3(0, GetComponent<SpriteRenderer>().bounds.extents.y + 0.1f, 0), Color.red);
        //Debug.Log("Grounded?: " + isGrounded);
        //Debug.Log("Can Jump?: " + jumping);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !jumping)
        {
            jumping = true;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMove);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        if (jumping)
        {
            Jump();
        }

        if (horizontalMove < 0.0f && facingRight)
        {
            Flip();
        }
        else if (horizontalMove > 0.0f && !facingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
        jumping = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
