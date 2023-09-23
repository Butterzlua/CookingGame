using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    private string currentRecipe;
    private Dictionary<string, Sprite> cookbook = new Dictionary<string, Sprite>();
    private Dictionary<string, float> cookTimes = new Dictionary<string, float>();
    public string[] recipes;
    public Sprite[] cookedFood;
    public float[] cookingTimes;
    public SpriteRenderer foodImage;
    [SerializeField] private GameObject newParent;
    [SerializeField] private ParticleSystem Smoke;
    public GameObject spritePosition;

    private void Start()
    {
        InitializeCookbook();
    }

    private void InitializeCookbook()
    {
        //if (recipes.Length > 0 && cookedFood.Length > 1 && recipes.Length == cookedFood.Length)
        {
            for (int i = 0; i <= recipes.Length - 1; i++)
            {
                cookbook.Add(recipes[i], cookedFood[i]);
            }
            for (int i = 0; i <= recipes.Length - 1; i++)
            {
                cookTimes.Add(recipes[i], cookingTimes[i]);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bowl"))
        {
            currentRecipe = collision.gameObject.GetComponent<BowlFunction>().currentRecipe;
            print(currentRecipe);
            CheckRecipe(currentRecipe);
        }
    }

    private void CheckRecipe(string recipe)
    {
        foreach(string r in recipes)
        {
            if (r == recipe)
            {
                if (!foodImage)
                {
                    print("oops");
                    return;
                }

                float time = cookTimes[r];
                //play cooking animation
                StartCoroutine(PlayCookingAnimation(r, recipe, time));
                //then show cooked sprite
            }    
        }
    }

    private IEnumerator PlayCookingAnimation(string r, string recipe, float time)
    {
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(time);

        GetComponent<ParticleSystem>().Stop();
        CookFood(r, recipe);
    }

    private void CookFood(string r, string recipe)
    {
        GameObject go = Instantiate(foodImage.gameObject, spritePosition.transform.position, transform.rotation, transform);
        if (r == "GroundBeef" || r == "CookedHotdog")
        {
            foodImage.gameObject.tag = "CookedIngredient";
            if (go)
                go.name = "CookedGrounBeefGO";
            else
                print("destroyed???");
        }
        else
        {
            foodImage.gameObject.tag = "FinishedFood";
        }

        if (foodImage.gameObject.CompareTag("CookedIngredient"))
        {
            foodImage.gameObject.AddComponent<TakeIngedidnet>();
            foodImage.GetComponent<TakeIngedidnet>().IngredientName = "Cooked" + r;
        }
        foodImage.sprite = cookbook[r];
        foodImage.gameObject.name = currentRecipe;
        print(foodImage.gameObject.name);
        foodImage.gameObject.transform.parent = newParent.transform;
        //if(go)
        foodImage = go.GetComponent<SpriteRenderer>();
        spritePosition = foodImage.gameObject;
        recipe = "Nothing";
    }
}
