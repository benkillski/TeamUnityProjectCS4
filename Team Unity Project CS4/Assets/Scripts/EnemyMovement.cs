using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 0.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -6)
        {
            dirRight = true;
        }
    }
}
