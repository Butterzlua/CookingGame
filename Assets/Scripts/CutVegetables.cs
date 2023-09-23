using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutVegetables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cuttable"))
        {
            collision.gameObject.tag = "Untagged";
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<TakeIngedidnet>().cutSprite;
            collision.gameObject.GetComponent<TakeIngedidnet>().IngredientName = "Cut" + collision.gameObject.GetComponent<TakeIngedidnet>().IngredientName;
        }
    }
}
