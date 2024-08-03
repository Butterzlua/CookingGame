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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && otherStuff.activeInHierarchy == true)
        {
            Return();
        }
    }


        public void Return()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            GameManager.instance.Paused = false;
        }
        Time.timeScale = 1;
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        otherStuff.SetActive(false);
    }
}
