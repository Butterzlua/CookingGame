using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static StarManager SM_Instance;
    public float Stars;
    [SerializeField] private GameObject[] starGameOBJS;
    public Texture2D emptyStar;
    public Texture2D HalfStar;
    public Texture2D FullStar;
    private void Awake()
    {
        if (SM_Instance == null)
        {
            SM_Instance = this;
        }
        else
        {
            Destroy(SM_Instance.gameObject);
        }

        if (PlayerPrefs.HasKey("Stars"))
        {
            Stars = PlayerPrefs.GetFloat("Stars");
            changeSprites();
        }
        else
        {
            Stars = 0;
        }
    }

    private void changeSprites()
    {
        //int stars = (int)(Stars * 2);
        //stars = Mathf.Clamp(stars, 0, 10);

        float starsRounded = Mathf.Clamp((int)Stars + 0.5f, 0, 5);

        for (int i = 1; i <= 5; i++)
        {
            GameObject.Find($"Star{i}").GetComponent<StarScript>().UpdateStar(starsRounded);
        }

        #region switch
        /*switch (stars)
        {
            default:
                GameObject.Find($"Star1").GetComponent<StarScript>().UpdateStar(0);
                GameObject.Find($"Star2").GetComponent<StarScript>().UpdateStar(0);
                GameObject.Find($"Star3").GetComponent<StarScript>().UpdateStar(0);
                GameObject.Find($"Star4").GetComponent<StarScript>().UpdateStar(0);
                GameObject.Find($"Star5").GetComponent<StarScript>().UpdateStar(0);
                break;
            case (1):
                GameObject.Find($"Star1").GetComponent<StarScript>().UpdateStar(1);
                break;
            case (2):
                GameObject.Find($"Star1").GetComponent<StarScript>().UpdateStar(2);
                break;
            case (3):
                GameObject.Find($"Star2").GetComponent<StarScript>().UpdateStar(1);
                break;
            case (4):
                GameObject.Find($"Star2").GetComponent<StarScript>().UpdateStar(2);
                break;
            case (5):
                GameObject.Find($"Star3").GetComponent<StarScript>().UpdateStar(1);
                break;
            case (6):
                GameObject.Find($"Star3").GetComponent<StarScript>().UpdateStar(2);
                break;
            case (7):
                GameObject.Find($"Star4").GetComponent<StarScript>().UpdateStar(1);
                break;
            case (8):
                GameObject.Find($"Star4").GetComponent<StarScript>().UpdateStar(2);
                break;
            case (9):
                GameObject.Find($"Star5").GetComponent<StarScript>().UpdateStar(1);
                break;
            case (10):
                GameObject.Find($"Star5").GetComponent<StarScript>().UpdateStar(2);
                break;
        }*/
        #endregion
    }

    public void updateStar(float starAdd)
    {
        Stars += starAdd;
        Stars = Mathf.Clamp(Stars, 0, 5);
        changeSprites();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Stars", Stars);
    }
}
/*
 * if ((int)(Stars * 2) % 2 == 0)
            {
                int stars = Mathf.Clamp((int)Mathf.Round(Stars), 1, 5);
                for(int i = 1; i < stars; i++)
                {
                    GameObject.Find($"Star{i}").GetComponent<RawImage>().texture = FullStar;
                }
            }
            else
            {
                int stars = Mathf.Clamp((int)Mathf.Round(Stars), 1, 5);                
                GameObject.Find($"Star{stars}").GetComponent<RawImage>().texture = HalfStar; 
            }
*
        /*
         * stars = mathf.clamp(stars, 0, 5);
         * GameObject.Find($"Star{(int)Mathf.round(stars)"}).GetComponent<RawImage>().texture = stars % 2 = 0.5 ? HalfStar : FullStar;
//         */
//if (Stars >= 0.5f)
//{
//    //1.7 - 3.4 - 3 -1
//
//
//}
//else
//{
//    int stars = Mathf.Clamp((int)Mathf.Round(Stars), 1, 5);
//    GameObject.Find($"Star{stars}").GetComponent<RawImage>().texture = emptyStar;
//}