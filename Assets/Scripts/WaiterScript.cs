using UnityEngine;

public class WaiterScript : MonoBehaviour
{
    public void Serving()
    {
        GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true);
        GetComponentInChildren<ThoughtBubble>().SetFoodImage(FoodManager.FM_instance.currentFoodSprite);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TableScript>().active)
        {
            if(FoodManager.FM_instance.currentFoodSprite == other.GetComponentInChildren<ThoughtBubble>().foodInHand.sprite)
            {
                print("Thanks!");
            }
            else
            {
                print("this aint what i ordered!");
            }
        }
    }
}
