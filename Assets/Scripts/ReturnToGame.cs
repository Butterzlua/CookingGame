using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReturnToGame : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject otherStuff;

    private void Start()
    {
        text = this.GetComponent<TMP_Text>();
    }


    public void Return()
    {
        Time.timeScale = 1;
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        otherStuff.SetActive(false);
    }
}
