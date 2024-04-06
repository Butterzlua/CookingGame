using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    public int value = 0;
    public Texture2D emptyStar;
    public Texture2D halfStar;
    public Texture2D fullStar;

    public void UpdateStar(float val)
    {
        switch (gameObject.name)
        {
            case ("Star1"):
                if(val >= 1)
                    GetComponent<RawImage>().texture = fullStar;
                else if (val >= 0.5f)
                    GetComponent<RawImage>().texture = halfStar;
                else if (val >= 0)
                    GetComponent<RawImage>().texture = emptyStar;
                break;
            case ("Star2"):
                if(val >= 2)
                    GetComponent<RawImage>().texture = fullStar;
                else if (val >= 1.5f)
                    GetComponent<RawImage>().texture = halfStar;
                else if (val >= 1)
                    GetComponent<RawImage>().texture = emptyStar;
                break;
            case ("Star3"):
                if(val >= 3)
                    GetComponent<RawImage>().texture = fullStar;
                else if (val >= 2.5f)
                    GetComponent<RawImage>().texture = halfStar;
                else if (val >= 2)
                    GetComponent<RawImage>().texture = emptyStar;
                break;
            case ("Star4"):
                if(val >= 4)
                    GetComponent<RawImage>().texture = fullStar;
                else if (val >= 3.5f)
                    GetComponent<RawImage>().texture = halfStar;
                else if (val >= 3)
                    GetComponent<RawImage>().texture = emptyStar;
                break;
            case ("Star5"):
                if(val >= 5)
                    GetComponent<RawImage>().texture = fullStar;
                else if (val >= 4.5f)
                    GetComponent<RawImage>().texture = halfStar;
                else if (val >= 4)
                    GetComponent<RawImage>().texture = emptyStar;
                break;
            
        }
    }
}
