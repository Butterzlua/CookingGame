using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public static FoodManager FM_instance;
    public static event Action<bool> onTableDeactivated;

    [Header("2D Stuff")]
    public GameObject conveyorInAction, Conveyor1, Conveyor2;
    public string CookingType;
    public enum ct
    {
        boil,
        deepfty,
    }
    public ct type;

    [Header("Camera")]
    public Camera camera2D;

    [Header("Skills")]
    public float CutTime = 6f;
    public float CookMultiplier = 1f;

    [Header("Current recipe name and sprite")]
    public string currentRecipe;
    public int CurrentSaltAmount = 0;
    public int CurrentPepperAmount = 0;
    public Sprite currentFoodSprite;

    [Header("UI")]
    public int page = 1;
    public GameObject cookingBook;

    [Header("Dictionaries")]
    public Dictionary<string, Sprite> cookbook = new Dictionary<string, Sprite>();
    public Dictionary<string, float> cookTimes = new Dictionary<string, float>();
    public Dictionary<string, GameObject> foodGameobjects = new Dictionary<string, GameObject>();
    public Dictionary<string, float> foodCosts = new Dictionary<string, float>();
    public Dictionary<string, Vector2Int> SnP_Table = new Dictionary<string, Vector2Int>();

    [Header("Ingredient names and sprites")]
    public List<SpriteRenderer> ingredientList = new List<SpriteRenderer>();
    public List<Sprite> ingredientSprites = new List<Sprite>();

    [Header("Array of all recipe names, cooking times, finished food sprites")]
    public string[] recipes;
    public Sprite[] cookedFood;
    public float[] cookingTimes;
    public float[] cookingCosts;
    public Vector2Int[] snp;

    [Header("3D")]
    public TableScript[] tables; 
    public GameObject[] cookedFoodGameobjects;
    public WaiterScript waiter;
    public GameObject wPlate;
    public Sprite[] tempSprites;

    [Header("Cooking Book")]
    public RecipeScriptableObject[] recipeSO;
    public OpenCookbook openCookBook;
    bool bConveyor1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && GameManager.instance.IsCooking)
        {
            cookingBook.SetActive(!cookingBook.activeInHierarchy);
            if (page == 0)
            {
                if(!openCookBook)
                {
                    print("no cookbook");
                }
                if(!recipeSO[page])
                {
                    print("no page");
                }
                openCookBook.UpdatePage(recipeSO[page]);   
            }
            else
            {
                openCookBook.UpdatePage(recipeSO[page - 1]);
            }
        }
        if (cookingBook.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (page < 2)
                {
                    page = recipeSO.Length;
                }
                else
                {
                    page--;
                }
                openCookBook.UpdatePage(recipeSO[page - 1]);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (page >= recipeSO.Length)
                {
                    page = 1;
                }
                else
                {
                    page++;
                }
                openCookBook.UpdatePage(recipeSO[page - 1]);
            }
        }    
        if(conveyorInAction.transform.localPosition.x > 97.45f)
        {
            bConveyor1 = !bConveyor1;
            conveyorInAction = bConveyor1 ? Conveyor1 : Conveyor2;
        }
    }

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

        waiter = GameObject.FindObjectOfType<WaiterScript>();
        tempSprites = Resources.LoadAll<Sprite>("Sprites");
    }
    private void Start()
    {       
        InitializeCookbook();
        GenerateRandomNumber();
        initalizeFood();
    }

    private void InitializeCookbook()
    {
        //if (recipes.Length > 0 && cookedFood.Length > 1 && recipes.Length == cookedFood.Length)
        {
            if(recipes.Length > 0)
            {
                if(cookedFood.Length > 0)
                {
                    for (int i = 0; i <= recipes.Length - 1; i++)
                    {
                        cookbook.Add(recipes[i], cookedFood[i]);
                    }
                }
                
                if (cookingTimes.Length > 0)
                {
                    for (int i = 0; i <= recipes.Length - 1; i++)
                    {
                        cookTimes.Add(recipes[i], cookingTimes[i]);
                    }
                }
                
                if (cookedFoodGameobjects.Length > 0)
                {
                    for (int i = 0; i <= recipes.Length - 1; i++)
                    {
                        foodGameobjects.Add(recipes[i], cookedFoodGameobjects[i]);
                    }
                } 
                
                if (cookingCosts.Length > 0)
                {
                    for (int i = 0; i <= recipes.Length - 1; i++)
                    {
                        foodCosts.Add(recipes[i], cookingCosts[i]);
                    }
                }
                
                if (snp.Length > 0)
                {
                    for (int i = 0; i <= recipes.Length - 1; i++)
                    {
                        SnP_Table.Add(recipes[i], snp[i]);
                    }
                }
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
            if(tables[tableIndex].name == "FrenchToast")
            {
                tables[tableIndex].GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true);
                tables[tableIndex].GetComponentInChildren<ThoughtBubble>().SetFoodImage(cookbook["FrenchToast"]);
            }
            else
            {
                if (foodGameobjects[recipes[menuItem]].CompareTag("CookedIngredient"))
                {
                    GenerateRandomNumber();
                }
                else
                {
                    tables[tableIndex].GetComponentInChildren<ThoughtBubble>().gameObject.SetActive(true);
                    tables[tableIndex].GetComponentInChildren<ThoughtBubble>().SetFoodImage(cookbook[recipes[menuItem]]);
                }
            }
        }        
    }

    public void GenerateRandomNumber()
    {
        int randomTable = UnityEngine.Random.Range(0, tables.Length);
        int randomFood = UnityEngine.Random.Range(0, cookbook.Count);
        onTableDeactivated?.Invoke(true);
        OrderFood(randomTable, randomFood);
    }

    public void CheckRecipe2D(string foodname)
    {
        //if(foodname == currentRecipe)
        {
            if (wPlate.GetComponent<WaitersPlate>().CheckRecipe(foodname))
                CameraTransition();
            else
                print("invalid recipe");
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

    public void initalizeFood()
    {
        //    cookingBook.transform.Find("FinalProduct").GetComponent<Image>().sprite = cookbook[recipes[page]];
        //cookingBook.transform.Find("FinalProduct").GetComponent<Image>().sprite = cookbook[recipes[page]];
        //cookingBook.transform.Find("FoodName").GetComponent<Text>().text = cookbook[recipes[page]].name;
        //    cookingBook.transform.Find("Amount").GetComponent<Text>().text = SnP_Table[recipes[page]].x.ToString();
        //    cookingBook.transform.Find("Amount2").GetComponent<Text>().text = SnP_Table[recipes[page]].y.ToString();
        //UpdatePage();
    }

    public void UpdatePage()
    {
        cookingBook.transform.Find("PageNumber").GetComponent<Text>().text = page.ToString();
        LoadIngredients();
    }

    private void LoadIngredients()
    {
        for(int i = 0; i < tempSprites.Length; i++)
        {
            cookingBook.transform.Find($"Ingredient{i}").GetComponent<Image>().sprite = tempSprites[i];
        }     
    }
}
