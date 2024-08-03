using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;
        collision.transform.position = transform.position;
    }
}
