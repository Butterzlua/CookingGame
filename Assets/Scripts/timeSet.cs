using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeSet : MonoBehaviour
{
    [SerializeField] private Text textClock;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime time = System.DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

        textClock.text = hour + ":" + minute;
    }
    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
