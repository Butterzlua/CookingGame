using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop1 : MonoBehaviour //, IDropHandler
{

    public string slotName;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.tag == slotName)
        {
            Drag draggable = eventData.pointerDrag.GetComponent<Drag>();
            if(draggable != null)
            {
                draggable.startPosition = transform.position;
            }
        }
    }
}
