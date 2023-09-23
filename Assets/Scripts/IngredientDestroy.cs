using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<TakeIngedidnet>())
        {
            Destroy(collision.gameObject);
        } else if(collision.GetComponent<RenewableIngredient>())
        {
            collision.transform.position = collision.GetComponent<RenewableIngredient>().originalPosition;
        }
    }
}
