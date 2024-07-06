using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-1.5f, 0, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(1.5f, 0, 0);

    }
}
