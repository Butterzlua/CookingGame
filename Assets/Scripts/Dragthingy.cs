using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragthingy : MonoBehaviour
{
    public Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 StartingPos;
    [SerializeField] private bool isntFood;
    private Vector2 screenExtents, mousePos;
    public bool isDragging;

    protected virtual void Start()
    {
        StartingPos = transform.position;
        CURRENT_STATE = STATE.NONE;
    }

    public enum STATE
    {
        NONE,
        DRAGGING, 
    }
    public STATE CURRENT_STATE;

    protected virtual void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;

            if (!GameManager.instance.IsCooking)
            {
                ResetPos();
            }

            if (transform.localPosition.x > 1.2f || transform.localPosition.x < -1.961f || transform.localPosition.y > 9.5f || transform.localPosition.y < -4.5f)
            {
                isDragging = false;
                ResetPos();
            }
        }
        else
        {
            ResetPos();
        }
    }

    public void ChangeState(STATE state)
    {
        CURRENT_STATE = state;

        switch(CURRENT_STATE)
        {
            case STATE.DRAGGING: isDragging = true; break;
            case STATE.NONE: 
                isDragging = false;
                ResetPos();
                break;
        }
    }

    protected virtual void ContinueDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 curRotation = new Vector3(0, 0, 0);
        transform.position = curPosition;
        transform.rotation = Quaternion.Euler(curRotation);
    }

    protected virtual void ResetPos()
    {
        transform.position = StartingPos;
        //MouseManager.instance.currentObject = null;
    }
    //protected virtual void OnMouseDown()
    //{
    //    isDragging = true;
    //    if (isntFood)
    //    {
    //        if (!GameManager.instance.IsCooking)
    //        {
    //            StartDrag();
    //        }
    //        else
    //        {
    //            gameObject.transform.position = StartingPos;
    //        }
    //    }
    //    else
    //    {
    //        StartDrag();
    //    }
    //}

    //void OnMouseDrag()
    //{
    //    if (isntFood)
    //    {
    //        if (GameManager.instance.IsCooking)
    //        {
    //            ContinueDrag();
    //        }
    //        else
    //        {
    //            gameObject.transform.position = StartingPos;
    //        }
    //    }
    //    else
    //    {
    //        ContinueDrag();
    //    }
    //}

    //protected virtual void OnMouseUp()
    //{
    //    isDragging = false;
    //    if (transform.localPosition.x > 1.2f || transform.localPosition.x < -0.5f || transform.localPosition.y > 9.5f || transform.localPosition.y < -4.5f)
    //        ResetPos();
    //}

    private void StartDrag()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
}



