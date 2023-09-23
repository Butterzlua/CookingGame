﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewableIngredient : MonoBehaviour
{
    [SerializeField] private GameObject newParent;
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool canDrag = false;
    public Vector3 originalPosition;

    public string IngredientName;
    // Start is called before the first frame update

    private void Start()
    {
        originalPosition = transform.position;
        newParent = GameObject.Find("2DCooking");
    }

    private void Update()
    {
        //if(canDrag)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //    transform.position = mousePos;
        //}
    }

    void OnMouseDown()
    {
        transform.parent = newParent.transform;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 curRotation = new Vector3(0, 0, 0);
        transform.position = curPosition;
        transform.rotation = Quaternion.Euler(curRotation);

        //transform.Rotate(new Vector3(0, 0, -90));
    }

    private void OnMouseUp()
    {
        transform.position = GetComponent<RenewableIngredient>().originalPosition;
    }
}
