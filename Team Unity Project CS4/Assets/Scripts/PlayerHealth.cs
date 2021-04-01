using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject deadPlayerPrefab;
    public void KillPlayer()
    {
        Instantiate<GameObject>(deadPlayerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
