using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragthingy : MonoBehaviour
{
    public Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {

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
}
