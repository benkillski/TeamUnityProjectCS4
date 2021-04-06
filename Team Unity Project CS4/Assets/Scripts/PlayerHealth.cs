using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject deadPlayerPrefab;
    [SerializeField] GameObject gameOverScreen;
    public void KillPlayer()
    {
        Instantiate(deadPlayerPrefab, transform.position, Quaternion.identity);
        gameOverScreen.SetActive(true);
        Destroy(gameObject);
    }
}
