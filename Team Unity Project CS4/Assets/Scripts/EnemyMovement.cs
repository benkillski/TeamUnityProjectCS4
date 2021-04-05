using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Edge Checking")]
    [SerializeField] private Transform edgeCheck;
    private bool isEdge;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(edgeCheck.transform.position, Vector2.down);
        
        Debug.Log(hit.collider);
        if (hit.collider.tag == "DeathZone" || hit.collider == null)
            Flip();

        Debug.DrawRay(edgeCheck.transform.position, Vector2.down, Color.red);
        rb.velocity = transform.right * moveSpeed;


    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
