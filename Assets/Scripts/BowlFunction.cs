using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlFunction : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> ingredientList = new List<SpriteRenderer>();
    [SerializeField] private List<Sprite> ingredientSprites = new List<Sprite>();
    private List<string> currentIngredients = new List<string>();
    private int ingredientsInBowl = 0;
    public string currentRecipe = "nothing";

    private void Start()
    {
        InitializeIngredientsList();
    }

    private void InitializeIngredientsList()
    {
        SpriteRenderer[] SR = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in SR)
        {
            ingredientList.Add(sr);
        }
        ingredientList.RemoveAt(0);
    }

    private void Update()
    {
        if (ingredientsInBowl == 1)
        {
            GroundBeef();
            CookedHotDog();
        }
        else if (ingredientsInBowl >= 2)
        {
            FrenchToast();
            Burger();
            Hotdog();
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TakeIngedidnet>())
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                if (ingredientsInBowl < ingredientList.Count)
                {
                    ingredientSprites.Add(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
                    for (int i = 0; i < ingredientSprites.Count; i++)
                    {
                        ingredientList[i].sprite = ingredientSprites[i];
                        ingredientsInBowl = ingredientSprites.Count;
                    }
                    currentIngredients.Add(collision.gameObject.GetComponent<TakeIngedidnet>().IngredientName);
                    Destroy(collision.gameObject);
                }
                else
                {
                    Debug.Log($"Bowl is full! It has {ingredientsInBowl}");
                }
            }
        }
        else if (collision.GetComponent<RenewableIngredient>())
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                if (ingredientsInBowl < ingredientList.Count)
                {
                    ingredientSprites.Add(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
                    for (int i = 0; i < ingredientSprites.Count; i++)
                    {
                        ingredientList[i].sprite = ingredientSprites[i];
                        ingredientsInBowl = ingredientSprites.Count;
                    }
                    currentIngredients.Add(collision.gameObject.GetComponent<RenewableIngredient>().IngredientName);
                    collision.transform.position = collision.GetComponent<RenewableIngredient>().originalPosition;
                }
                else
                {
                    Debug.Log($"Bowl is full! It has {ingredientsInBowl}");
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IngredientDestroy>())
        {
            ClearBowl();
        }
        if (collision.gameObject.GetComponent<CookingScript>())
        {
            ClearBowl();
            currentRecipe = "Nothing";
        }
    }

    public void ClearBowl()
    {
        for (int i = 0; i < ingredientList.Count; i++)
        {
            ingredientList[i].sprite = null;
        }
        ingredientSprites.Clear();
        ingredientsInBowl = 0;
        currentIngredients.Clear();
    }

    private bool FrenchToast()
    {
        if(ingredientsInBowl >= 4)
        {
            if (currentIngredients.Contains("Milk") && currentIngredients.Contains("Vanilla") && currentIngredients.Contains("Egg") && currentIngredients.Contains("Cinnamon"))
            {
                currentRecipe = "FrenchToast";
                return true;       
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }        
    }

    private bool GroundBeef()
    {
        if (ingredientsInBowl == 1)
        {
            if (currentIngredients.Contains("GroundBeef"))
            {
                currentRecipe = "GroundBeef";
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private bool CookedHotDog()
    {
        if (ingredientsInBowl == 1)
        {
            if (currentIngredients.Contains("Hotdog"))
            {
                currentRecipe = "CookedHotdog";
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private bool Hotdog()
    {
        if (ingredientsInBowl == 2)
        {
            if (currentIngredients.Contains("CookedCookedHotdog") && currentIngredients.Contains("HotDogBun"))
            {
                currentRecipe = "Hotdog";
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private bool Burger()
    {
        if (ingredientsInBowl == 5)
        {
            if (currentIngredients.Contains("Cheese") && currentIngredients.Contains("BurgerBun") && currentIngredients.Contains("CutLettuce") && currentIngredients.Contains("CutTomato") && currentIngredients.Contains("CookedGroundBeef"))
            {
                currentRecipe = "Burger";
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}