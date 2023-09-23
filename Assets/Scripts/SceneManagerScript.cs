using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
   
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Cooking2D")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                SceneManager.LoadScene(1);
            }
        }
        if (SceneManager.GetActiveScene().name == "CookingGame")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}
