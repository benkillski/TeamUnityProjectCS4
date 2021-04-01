using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            if((collision.gameObject.GetComponent<PlayerMovement>().isGrounded))
            {
                collision.gameObject.GetComponent<PlayerHealth>().KillPlayer();

            }
        }
    }
}
