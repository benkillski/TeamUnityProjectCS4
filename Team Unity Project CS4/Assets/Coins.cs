using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [Header("Coin Type")]
    [SerializeField] bool bronze, silver, gold;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (bronze)
            {
                collision.gameObject.GetComponent<PlayerScore>().AddScore(10);
            }
            else if (silver)
            {
                collision.gameObject.GetComponent<PlayerScore>().AddScore(50);
            }
            else if (gold)
            {
                collision.gameObject.GetComponent<PlayerScore>().AddScore(100);
            }
            Destroy(gameObject);
        }
    }
}
