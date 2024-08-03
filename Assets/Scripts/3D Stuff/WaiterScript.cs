using System;
using UnityEngine;

public class WaiterScript : MonoBehaviour
{
    [SerializeField] private MoneyScript script;
    [SerializeField] private AudioSource moeny;
    [SerializeField] private SpriteRenderer foodInHand;
    //Create an event that other scripts can "listen" or "subscribe" to.
    public static event Action<bool> onTableActivated;
    public void Serving()
    {
        GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true);
        GetComponentInChildren<ThoughtBubble>().SetFoodImage(FoodManager.FM_instance.currentFoodSprite);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (foodInHand.sprite == null)
            return;

        if(other.GetComponent<TableScript>().active == true)
        {
            if(GetComponentInChildren<ThoughtBubble>().foodInHand.sprite == other.GetComponentInChildren<ThoughtBubble>().foodInHand.sprite)
            {
                MoneyScript.MS_Instance.GiveMoney(FoodManager.FM_instance.foodCosts[FoodManager.FM_instance.currentRecipe],FoodManager.FM_instance.currentRecipe);
                FoodManager.FM_instance.currentRecipe = "Nothing";
                other.GetComponent<TableScript>().MoneyDispense(50);
                moeny.Play();
                FoodManager.FM_instance.currentFoodSprite = null;
                FoodManager.FM_instance.GenerateRandomNumber();

                //Fire a "signal" that triggers this event.
                //onTableActivated?.Invoke(false);
            }
            else
            {
                if (FoodManager.FM_instance.currentRecipe != "Nothing")
                {
                    StarManager.SM_Instance.updateStar(UnityEngine.Random.Range(-0.5f,-0.8f));
                }
            }

            if (GetComponentInChildren<ThoughtBubble>())
            {
                GetComponentInChildren<ThoughtBubble>().SetFoodImage(null);
            }
        }
    }
}
