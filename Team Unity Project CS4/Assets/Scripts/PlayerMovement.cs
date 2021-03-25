using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float horizontalMove = 0f;
    bool jump = false;
    bool facingRight = true;

    [SerializeField] float jumpForce = 300f;
    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontalMove);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
        }

        if (horizontalMove < 0.0f && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
        else if (horizontalMove > 0.0f && !facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }
}
