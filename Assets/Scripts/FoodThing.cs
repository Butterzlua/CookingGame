using UnityEngine;

public class FoodThing : MonoBehaviour
{
    public GameObject wPlate;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FinishedFood"))
        {
            print("Transitioning to 3D!");
            //play sound effect
            //Invoke(nameof(CameraTransition), 1f);
            CameraTransition();

            if (collision.gameObject.name == "FrenchToast")
            {
                wPlate.GetComponent<WaitersPlate>().CheckRecipe("FrenchToast");
            }
            else if (collision.gameObject.name == "Burger")
            {
                wPlate.GetComponent<WaitersPlate>().CheckRecipe("Burger");
            }
            else if (collision.gameObject.name == "Hotdog")
            {
                wPlate.GetComponent<WaitersPlate>().CheckRecipe("Hotdog");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FinishedFood"))
        {
            print("Transitioning to 3D!");
            //play sound effect
            //Invoke(nameof(CameraTransition), 1f);
            CameraTransition();

            if (collision.gameObject.name == "FrenchToast")
            {
                wPlate.GetComponent<WaitersPlate>().CheckRecipe("FrenchToast");
            } else if(collision.gameObject.name == "Burger")
            {
                wPlate.GetComponent<WaitersPlate>().CheckRecipe("Burger");
            }
            }
            else if (collision.gameObject.name == "Hotdog")
            {
                wPlate.GetComponent<WaitersPlate>().CheckRecipe("Hotdog");
            }
    }

    private void CameraTransition()
    {
       GameManager.instance.ToggleBetween2D3D();
    }
}
