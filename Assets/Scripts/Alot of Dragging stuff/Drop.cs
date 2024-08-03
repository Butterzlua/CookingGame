using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour //, IDropHandler
{

    //public string slotName;
    //public void OnDrop(PointerEventData eventData)
    //{
    //    if(eventData.pointerDrag.transform.name == slotName)
    //    {
    //        Drag draggable = eventData.pointerDrag.GetComponent<Drag>();
    //        if(draggable != null)
    //        {
    //            draggable.startPosition = transform.position;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CompareTag("SmallCookware"))
        {
            collision.gameObject.transform.position = transform.position;
        }
    }
}
