using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    void Start()
    {
        anim = GetComponent<Animator>();
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
        if (rb.velocity.x > 1 || rb.velocity.z > 1)
        {
            anim.speed = 1.5f;
            anim.SetBool("isidle", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.speed = 0.75f;
            anim.SetBool("isidle", true);
            anim.SetBool("isWalking", false);
        }
    }
}
