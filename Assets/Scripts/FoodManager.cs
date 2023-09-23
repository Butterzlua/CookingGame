using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static FoodManager FM_instance;
    public string currentRecipe;
    public Sprite currentFoodSprite;
    public Dictionary<string, Sprite> cookbook = new Dictionary<string, Sprite>();
    public string[] recipes;
    public Sprite[] cookedFood;
    public TableScript[] tables;

    private void Awake()
    {
        if (FM_instance == null)
        {
            FM_instance = this;
        }
        else
        {
            Destroy(FM_instance.gameObject);
        }
    }
    private void Start()
    {
        InitializeCookbook();
        GenerateRandomNumber();
    }

    private void InitializeCookbook()
    {
        //if (recipes.Length > 0 && cookedFood.Length > 1 && recipes.Length == cookedFood.Length)
        {
            for (int i = 0; i <= recipes.Length - 1; i++)
            {
                cookbook.Add(recipes[i], cookedFood[i]);
            }
        }
    }

    public void SetCurrentRecipe(string recipe)
    {
        currentRecipe = recipe;
    }
    
    public void SetCurrentFood(Sprite recipeSprite)
    {
        currentFoodSprite = recipeSprite;
    }

    private void OrderFood(int tableIndex, int menuItem)
    {
        if(tables[tableIndex].active)
        {
            tables[tableIndex].GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true);
            tables[tableIndex].GetComponentInChildren<ThoughtBubble>().SetFoodImage(cookbook[recipes[menuItem]]);
        }        
    }

    private void GenerateRandomNumber()
    {
        int randomTable = Random.Range(0, tables.Length);
        int randomFood = Random.Range(0, cookbook.Count);
        OrderFood(randomTable, randomFood);
    }
}
