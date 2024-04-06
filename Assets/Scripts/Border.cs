//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Border : MonoBehaviour
//{
//    Dragthingy dragyThing = null;
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.GetComponent<Dragthingy>())
//        {
//            dragyThing = collision.GetComponent<Dragthingy>();
//        }
//    }
    
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if(collision.GetComponent<Dragthingy>())
//        {
//            dragyThing = null; 
//        }
//    }

//    private void OnMouseUp()
//    {
//        if(dragyThing)
//            dragyThing.ResetPos();
//    }
//}
