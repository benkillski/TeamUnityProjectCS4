using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce((Vector2.up + Vector2.left) * 200);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
    }
}
