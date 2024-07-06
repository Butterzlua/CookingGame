using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitersPlate : MonoBehaviour
{
    public GameObject current3DFood;
    public bool CheckRecipe(string recipe)
    {
        foreach (string r in FoodManager.FM_instance.recipes)
        {
            if (r == recipe)
            {
                current3DFood = Instantiate(FoodManager.FM_instance.foodGameobjects[r], this.transform.position, this.transform.rotation, this.transform);
                FoodManager.FM_instance.currentRecipe = r;
                FoodManager.FM_instance.currentFoodSprite = FoodManager.FM_instance.foodGameobjects[r].GetComponentInChildren<SpriteRenderer>().sprite;
                return true;
            }
        }
        return false;

    }

    public void DestroyFood()
    {
        //Destroy(current3DFood);
        current3DFood.SetActive(false);
        current3DFood = null;
    }

    private void OnMouseUpAsButton()
    {
        List<string> recipeList = new List<string>();
            foreach(string s in FoodManager.FM_instance.recipes)
        {
            recipeList.Add(s);
        }
        if(recipeList.Contains(FoodManager.FM_instance.currentRecipe))
        {
            DestroyFood();
            GameManager.instance.SwitchCharacter();
            if (FoodManager.FM_instance.waiter.GetComponentInChildren<ThoughtBubble>())
            {
                FoodManager.FM_instance.waiter.GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true); 
                FoodManager.FM_instance.waiter.GetComponentInChildren<ThoughtBubble>().GetComponent<ThoughtBubble>().SetFoodImage(FoodManager.FM_instance.currentFoodSprite);

            }
        }
    }
}

//if (FoodManager.FM_instance.currentRecipe == "FrenchToast" || FoodManager.FM_instance.currentRecipe == "Burger" || FoodManager.FM_instance.currentRecipe == "Hotdog" || FoodManager.FM_instance.currentRecipe == "TomatoPasta"
            //|| FoodManager.FM_instance.currentRecipe == "Carbonara" || FoodManager.FM_instance.currentRecipe == "Fries")
