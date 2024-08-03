using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedFood : MonoBehaviour
{
    public int salt = 0, pepper = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Salt" || collision.gameObject.name == "Pepper")
        {
            if (collision.gameObject.name == "Salt")
            {
                salt++; 
            }
            else if (collision.gameObject.name == "Pepper")
            {
                pepper++;
            }
        }
    }
}
