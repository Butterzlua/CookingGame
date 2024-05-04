using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour
{
    public SpriteRenderer foodInHand;

    private void OnEnable()
    {
        //WaiterScript.onTableActivated += ActivateSprites;
        FoodManager.onTableDeactivated += ActivateSprites;
    }

    private void OnDisable()
    {
        //WaiterScript.onTableActivated -= ActivateSprites;
        FoodManager.onTableDeactivated -= ActivateSprites;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = GameManager.instance.m_MainCamera;
        if (!cam.gameObject.activeSelf) return;
        transform.LookAt(cam.transform);
    }

    public void SetFoodImage(Sprite food)
    {
        if (food == null)
        {
            foodInHand.sprite = null;
        }
        else
        {
            foodInHand.gameObject.SetActive(true);
            foodInHand.sprite = food;
        }
    }    
    public void ActivateSprites(bool activate)
    {
        if(activate)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            foodInHand.enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            foodInHand.enabled = false;
        }        
    }
}
