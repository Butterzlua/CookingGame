using UnityEngine;

//Script attached to 2D plate
public class FoodThing : MonoBehaviour
{
    public GameObject wPlate;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinishedFood"))
        {
            print("Transitioning to 3D!");
            FoodManager.FM_instance.CheckRecipe2D(collision.gameObject.name);
            //play sound effect
            //Invoke(nameof(CameraTransition), 1f);

            //if (collision.gameObject.name == "FrenchToast")
            //{
            //    wPlate.GetComponent<WaitersPlate>().CheckRecipe("FrenchToast");
            //    CameraTransition();
            //}
            //else if (collision.gameObject.name == "Burger")
            //{
            //    wPlate.GetComponent<WaitersPlate>().CheckRecipe("Burger");
            //    CameraTransition();
            //}
            //else if (collision.gameObject.name == "PastaTomato")
            //{
            //    wPlate.GetComponent<WaitersPlate>().CheckRecipe("TomatoPasta");
            //    CameraTransition();
            //}
            //else
            //{
            //    wPlate.GetComponent<WaitersPlate>().CheckRecipe("Hotdog");
            //    CameraTransition();
            //}
        }
    }

    private void CameraTransition()
    {
        GameObject FF = FindObjectOfType<FinishedFood>().gameObject;
        if (FF)
        {
            FoodManager.FM_instance.CurrentSaltAmount = FindObjectOfType<FinishedFood>().salt;
            FoodManager.FM_instance.CurrentPepperAmount = FindObjectOfType<FinishedFood>().pepper;
            Destroy(FF);
        }
       GameManager.instance.ToggleBetween2D3D();
    }
}
