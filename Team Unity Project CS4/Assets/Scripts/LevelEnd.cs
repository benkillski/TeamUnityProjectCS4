using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Level Completed");
            FindObjectOfType<GameTimer>().StopTimer();
            collision.gameObject.GetComponent<PlayerScore>().AddScore(500);
        }
    }
}
