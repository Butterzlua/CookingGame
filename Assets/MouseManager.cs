using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;
    public Dragthingy currentObject;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Camera cam = GameManager.instance.m_CameraTwo;
            if (!cam.gameObject.activeSelf) return;
            Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray, Vector2.zero);

            foreach(RaycastHit2D hit in hits)
            {
                if (hit.collider.CompareTag("Draggable"))
                {
                    if(currentObject)
                    {
                        currentObject.isDragging = false;
                    }
                    currentObject = hit.collider.GetComponent<Dragthingy>();
                    currentObject.isDragging = true;
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (currentObject)
            {
                currentObject.isDragging = false;
                currentObject = null;
            }
        }
    }
}
