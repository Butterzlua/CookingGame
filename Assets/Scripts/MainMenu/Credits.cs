using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Credits : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private void OnMouseOver()
    {
        text.fontStyle = FontStyles.Underline | FontStyles.Italic;
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnMouseExit()
    {
        text.fontStyle = FontStyles.Normal;
    }

}
