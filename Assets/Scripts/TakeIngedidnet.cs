using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeIngedidnet : MonoBehaviour
{
    [SerializeField] private GameObject newParent;
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool canDrag = false;
    public string IngredientName;
    public Sprite cutSprite;
    public bool Cutting = false;
    // Start is called before the first frame update
   
    private void Start()
    {
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
        if (!Cutting)
        {
            transform.parent = newParent.transform;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        }
    }

    void OnMouseDrag()
    {
        if (!Cutting)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            Vector3 curRotation = new Vector3(0, 0, 0);
            transform.position = curPosition;
            transform.rotation = Quaternion.Euler(curRotation);
        }
    }
}

//private void OnMouseDown()
//{
//    Debug.Log("Mouse Down");
//    canDrag = true;
//    transform.parent = newParent.transform;
//    //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
//}

//private void OnMouseUp()
//{
//    canDrag = false;
//    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//    mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
//    transform.position = mousePos;
//}

//void OnMouseDrag()
//{
//    //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//    //Vector3 curPosition = transform.position;
//    //Vector3 curRotation = new Vector3(0, 0, 0);
//    //transform.position = curScreenPoint;
//    //transform.rotation = Quaternion.Euler(curRotation);
//    //transform.parent = newParent.transform;

//}