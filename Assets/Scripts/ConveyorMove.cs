using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMove : MonoBehaviour
{
    public float SpeedConveyor = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.right * Time.deltaTime * SpeedConveyor);
        if(transform.localPosition.x > 94)
        {
            Vector3 temp = transform.localPosition;
            temp.x = -94;
            transform.localPosition = temp;
        }
    }
}
