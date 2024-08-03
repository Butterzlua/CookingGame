using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCookbook : MonoBehaviour
{
    [SerializeField] private Image[] ingredients;
    [SerializeField] private Image finalProduct;
    [SerializeField] private Text salt, pepper, page, cookingTime, CookingCost, FoodName;
    [SerializeField] private AudioSource sound;

    public void UpdatePage(RecipeScriptableObject recipe)
    {
        sound.Play();
        page.text = recipe.pageNumber.ToString();
        salt.text = recipe.SaltAndPepper.x.ToString();
        pepper.text = recipe.SaltAndPepper.y.ToString();
        FoodName.text = recipe.recipeName;
        CookingCost.text = recipe.cost.ToString();
        cookingTime.text = recipe.cookingTime.ToString();
        finalProduct.sprite = recipe.recipeSprite2D;

        int temp = recipe.ingredientSprites.Length;
        for(int i = 0; i < temp; i++)
        {
            ingredients[i].sprite = recipe.ingredientSprites[i];
        }
    }
}
