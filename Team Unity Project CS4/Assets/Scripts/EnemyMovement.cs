using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    bool facingRight = false;

    [Header("Edge Checking")]
    [SerializeField] private Transform edgeCheck;
    private bool isEdge;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isEdge = Physics2D.Raycast(edgeCheck.transform.position, Vector2.down);
        if (!isEdge)
            Flip();

        Debug.DrawRay(edgeCheck.transform.position, Vector2.down, Color.red);

        rb.velocity = new Vector2(transform.position.x * moveSpeed, rb.velocity.y);
        Debug.Log(rb.velocity);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
