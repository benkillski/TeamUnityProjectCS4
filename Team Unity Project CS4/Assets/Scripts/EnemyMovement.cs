using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool dirRight = true;
    public float speed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
