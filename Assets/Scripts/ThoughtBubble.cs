using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour
{
    public SpriteRenderer foodInHand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void SetFoodImage(Sprite food)
    {
        foodInHand.sprite = food;
    }
}
