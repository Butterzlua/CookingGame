using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform EndPos1;
    [SerializeField] private Transform EndPos2;
    [SerializeField] private Transform StartPos;
    [SerializeField] private Camera MainCam;
    private bool InKitchen, canMoveCam, InExtra, InDiner;
    // Start is called before the first frame update
    void Start()
    {
        InKitchen = true;
        InExtra = false;
        InDiner = false;
        canMoveCam = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveCam)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if(InExtra)
                {
                    moveCameraLeft();
                }
                else if (InKitchen)
                {
                    moveCameraRight();
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if(InDiner == false)
                {
                moveCameraLeft();
                }
                if (InDiner)
                {
                    moveCameraRight();
                }
            }
        }
    }


    private void moveCameraRight()
    {
        if (InKitchen)
        {
            StartCoroutine(TransitionCamera(StartPos.position, EndPos1.position));
            //MainCam.transform.position = EndPos.position;
            InKitchen = false;
            InDiner = true;
        }
        else
        {
            StartCoroutine(TransitionCamera(EndPos1.position, StartPos.position));
            //MainCam.transform.position = StartPos.position;
            InKitchen = true;
            InDiner = false;
        }
    }

    private IEnumerator TransitionCamera(Vector3 startPos, Vector3 endPos)
    {
        canMoveCam = false;
        float t = 0f;
        Vector3 start = startPos;
        Vector3 end = endPos;
        //var target = new Vector3(transform.position.x, maxHeight, transform.position.z);

        while (t < 1)
        {
            t += Time.deltaTime;

            if (t > 1) t = 1;

            MainCam.transform.position = Vector3.Lerp(start, end, t);

            yield return null;
        }
        canMoveCam = true;
    }

    private void moveCameraLeft()
    {
        if (InKitchen)
        {
            StartCoroutine(TransitionCamera(StartPos.position, EndPos2.position));
            //MainCam.transform.position = EndPos.position;
            InKitchen = false;
            InExtra = true;
        }
        else
        {
            StartCoroutine(TransitionCamera(EndPos2.position, StartPos.position));
            //MainCam.transform.position = StartPos.position;
            InKitchen = true;
            InExtra = false;
        }
    }

 
}
