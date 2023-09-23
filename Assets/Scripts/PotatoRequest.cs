using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoRequest : MonoBehaviour
{
    public GameObject potatoCounter;
    public GameObject potatoCounter2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        potatoCounter.SetActive(true);
        potatoCounter2.SetActive(true);
    }
}
