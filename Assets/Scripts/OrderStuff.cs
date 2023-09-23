using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderStuff : MonoBehaviour
{
    [SerializeField] private SpriteRenderer orderedFood;
    private float Food;
    // Start is called before the first frame update
    void Start()
    {
        Food = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
