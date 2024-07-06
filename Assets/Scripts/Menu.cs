using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text = this.GetComponent<TMP_Text>();
    }

    public void changeScene()
    {
        Time.timeScale = 1;
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        SceneManager.LoadScene(0);
    }
}
