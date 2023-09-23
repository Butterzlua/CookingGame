using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitersPlate : MonoBehaviour
{
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private string currentRecipe;
    private Dictionary<string, GameObject> cookbook = new Dictionary<string, GameObject>();
    public string[] recipes;
    public GameObject[] cookedFood;
    public WaiterScript waiter;

    private void Start()
    {
        InitializeCookbook();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (currentRecipe != null)
                print(currentRecipe);
            else
                print("null");
        }
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

    public void CheckRecipe(string recipe)
    {
        foreach (string r in recipes)
        {
            if (r == recipe)
            {
                GameObject go = Instantiate(cookbook[r], this.transform.position, this.transform.rotation, this.transform);
                currentRecipe = r;
                FoodManager.FM_instance.currentFoodSprite = cookbook[r].GetComponentInChildren<SpriteRenderer>().sprite;
            }
        }
    }

    private void OnMouseOver()
    {
        if (currentRecipe == "FrenchToast" || currentRecipe == "Burger" || currentRecipe == "Hotdog")
        {
            GameManager.instance.SwitchCharacter();
            if (waiter.GetComponentInChildren<ThoughtBubble>())
            {
                waiter.GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true);
                if(FoodManager.FM_instance.currentFoodSprite)
                {
                    waiter.GetComponentInChildren<ThoughtBubble>().SetFoodImage(FoodManager.FM_instance.currentFoodSprite);
                }
            }
        }
    }
}
