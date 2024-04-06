using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlFunction : MonoBehaviour
{
    private List<string> currentIngredients = new List<string>();
    private int ingredientsInBowl = 0;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource sound;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        InitializeIngredientsList();
        FoodManager.FM_instance.currentRecipe = "nothing";
}

    private void InitializeIngredientsList()
    {
        SpriteRenderer[] SR = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in SR)
        {
            FoodManager.FM_instance.ingredientList.Add(sr);
        }
        FoodManager.FM_instance.ingredientList.RemoveAt(0);
    }

    private void Update()
    {
        if (ingredientsInBowl == 1)
        {
            GroundBeef();
            CookedHotDog();
            TomatoSauce();
        }
        else if (ingredientsInBowl >= 2)
        {
            Pasta();
            FrenchToast();
            Burger();
            Hotdog();
            TomatoPasta();
            Carbonara();
            Fries();
            SousVide();
            Steak();
            Chicken();
            Rice();
            SpecialRice();
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TakeIngedidnet>())
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                if (ingredientsInBowl < FoodManager.FM_instance.ingredientList.Count)
                {
                    sound.Play();
                    particle.Emit(20);
                    FoodManager.FM_instance.ingredientSprites.Add(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
                    for (int i = 0; i < FoodManager.FM_instance.ingredientSprites.Count; i++)
                    {
                        FoodManager.FM_instance.ingredientList[i].sprite = FoodManager.FM_instance.ingredientSprites[i];
                        ingredientsInBowl = FoodManager.FM_instance.ingredientSprites.Count;
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
                if (ingredientsInBowl < FoodManager.FM_instance.ingredientList.Count)
                {
                    sound.Play();
                    particle.Emit(20);
                    FoodManager.FM_instance.ingredientSprites.Add(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
                    for (int i = 0; i < FoodManager.FM_instance.ingredientSprites.Count; i++)
                    {
                        FoodManager.FM_instance.ingredientList[i].sprite = FoodManager.FM_instance.ingredientSprites[i];
                        ingredientsInBowl = FoodManager.FM_instance.ingredientSprites.Count;
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
            collision.gameObject.GetComponent<IngredientDestroy>().SoundPlay();
        }
        if (collision.gameObject.GetComponent<CookingScript>())
        {
            ClearBowl();
            FoodManager.FM_instance.currentRecipe = "Nothing";
        }
    }

    public void ClearBowl()
    {
        for (int i = 0; i < FoodManager.FM_instance.ingredientList.Count; i++)
        {
            FoodManager.FM_instance.ingredientList[i].sprite = null;
        }
        FoodManager.FM_instance.ingredientSprites.Clear();
        FoodManager.FM_instance.CurrentSaltAmount = 0;
        FoodManager.FM_instance.CurrentPepperAmount = 0;
        ingredientsInBowl = 0;
        currentIngredients.Clear();
    }

    private bool FrenchToast()
    {
        if(ingredientsInBowl == 5)
        {
            if (currentIngredients.Contains("Milk") && currentIngredients.Contains("Vanilla") && currentIngredients.Contains("Egg") && currentIngredients.Contains("Cinnamon") && currentIngredients.Contains("Bread"))
            {
                FoodManager.FM_instance.currentRecipe = "FrenchToast";
                FoodManager.FM_instance.CookingType = "Stovetop";
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
                FoodManager.FM_instance.currentRecipe = "GroundBeef";
                FoodManager.FM_instance.CookingType = "Stovetop";
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
                FoodManager.FM_instance.currentRecipe = "CookedHotdog";
                FoodManager.FM_instance.CookingType = "Stovetop";
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

    private bool TomatoPasta()
    {
        if (ingredientsInBowl == 2)
        {
            if (currentIngredients.Contains("CookedPasta") && currentIngredients.Contains("CookedTomato Sauce"))
            {
                FoodManager.FM_instance.currentRecipe = "TomatoPasta";
                FoodManager.FM_instance.CookingType = "Stovetop";
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

    private bool Carbonara()
    {
        if (ingredientsInBowl >= 4)
        {
            if (currentIngredients.Contains("CookedPasta") && currentIngredients.Contains("Cheese") && currentIngredients.Contains("Egg") && currentIngredients.Contains("CutCuredMeat"))
            {
                FoodManager.FM_instance.currentRecipe = "Carbonara";
                FoodManager.FM_instance.CookingType = "Stovetop";
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
    private bool Pasta()
    {
        if (ingredientsInBowl >= 2)
        {
            if (currentIngredients.Contains("Water") && currentIngredients.Contains("Pasta"))
            {
                FoodManager.FM_instance.currentRecipe = "Pasta";
                FoodManager.FM_instance.CookingType = "Boil";
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
    private bool TomatoSauce()
    {
        if (ingredientsInBowl == 1)
        {
            if (currentIngredients.Contains("Tomato"))
            {
                FoodManager.FM_instance.currentRecipe = "Tomato Sauce";
                FoodManager.FM_instance.CookingType = "Stovetop";
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
                FoodManager.FM_instance.currentRecipe = "Hotdog";
                FoodManager.FM_instance.CookingType = "Stovetop";
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

    private bool Fries()
    {
        if (ingredientsInBowl == 2)
        {
            if (currentIngredients.Contains("CutPotato") && currentIngredients.Contains("Oil"))
            {
                FoodManager.FM_instance.currentRecipe = "Fries";
                FoodManager.FM_instance.CookingType = "Deepfry";
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

    private bool SousVide()
    {
        if (ingredientsInBowl == 2)
        {
            if (currentIngredients.Contains("Water") && currentIngredients.Contains("CutSteak"))
            {
                FoodManager.FM_instance.currentRecipe = "SousVide";
                FoodManager.FM_instance.CookingType = "Boil";
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

    private bool Steak()
    {
        if (ingredientsInBowl == 3)
        {
            if (currentIngredients.Contains("Butter") && currentIngredients.Contains("CookedSousVide") && currentIngredients.Contains("CookedTomatoSauce"))
            {
                FoodManager.FM_instance.currentRecipe = "Steak";
                FoodManager.FM_instance.CookingType = "Stovetop";
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
                FoodManager.FM_instance.currentRecipe = "Burger";
                FoodManager.FM_instance.CookingType = "Stovetop";
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
    
    private bool Chicken()
    {
        if (ingredientsInBowl == 4)
        {
            if (currentIngredients.Contains("CutChicken") && currentIngredients.Contains("CutChicken") && currentIngredients.Contains("CutChicken") && currentIngredients.Contains("Oil"))
            {
                FoodManager.FM_instance.currentRecipe = "FriedChicken";
                FoodManager.FM_instance.CookingType = "Deepfry";
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

    private bool Rice()
    {
        if (ingredientsInBowl == 3)
        {
            if (currentIngredients.Contains("RiceBag") && currentIngredients.Contains("Water") && currentIngredients.Contains("Water"))
            {
                FoodManager.FM_instance.currentRecipe = "Rice";
                FoodManager.FM_instance.CookingType = "Boil";
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

    private bool SpecialRice()
    {
        if (ingredientsInBowl == 3)
        {
            if (currentIngredients.Contains("CookedRice") && currentIngredients.Contains("CookedGroundBeef") && currentIngredients.Contains("Egg"))
            {
                FoodManager.FM_instance.currentRecipe = "SpecialRice";
                FoodManager.FM_instance.CookingType = "Stovetop";
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