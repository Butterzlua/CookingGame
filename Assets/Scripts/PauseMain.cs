using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMain : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] private GameObject PauseMenu;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
             PauseGame();
            }
        }

        void PauseGame()
        {
            // Set Time.timeScale to 0 to pause gameplay
            Time.timeScale = 0;
            // Make PauseMenu panel visible (activate its gameObject)
            PauseMenu.gameObject.SetActive(true);
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
