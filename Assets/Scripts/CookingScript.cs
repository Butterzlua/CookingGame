using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{  
    public SpriteRenderer foodImage;
    [SerializeField] private GameObject newParent;
    [SerializeField] private GameObject Smoke, Deepfry, Steam;
    [SerializeField] private Sprite Default, Oil, Boil;
    public GameObject spritePosition;
    [SerializeField] private AudioSource cookingSound;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bowl")
        {
            print(FoodManager.FM_instance.currentRecipe);
            CheckRecipe(FoodManager.FM_instance.currentRecipe);
        }
    }

    private void CheckRecipe(string recipe)
    {
        foreach(string r in FoodManager.FM_instance.recipes)
        {
            if (r == recipe)
            {
                if (!foodImage)
                {
                    print("oops");
                    return;
                }

                float time = FoodManager.FM_instance.cookTimes[r];
                StartCoroutine(PlayCookingAnimation(r, recipe, time));
            }    
        }
    }

    private IEnumerator PlayCookingAnimation(string r, string recipe, float time)
    {
        GameObject effect = null;
        SpriteRenderer starry = GetComponent<SpriteRenderer>();
        if (FoodManager.FM_instance.CookingType == "Stovetop")
        {
             effect = Instantiate(Smoke, transform.position, Quaternion.identity);
            starry.sprite = Default;
        }
        else if (FoodManager.FM_instance.CookingType == "Deepfry")
        {
            effect = Instantiate(Deepfry, transform.position, Quaternion.identity);
            starry.sprite = Oil;
        }
        else if (FoodManager.FM_instance.CookingType == "Boil")
        {
            effect = Instantiate(Steam, transform.position, Quaternion.identity);
            starry.sprite = Boil;
        }
        cookingSound.Play();
        yield return new WaitForSeconds(time / FoodManager.FM_instance.CookMultiplier);
        starry.sprite = Default;
        cookingSound.Stop();
        Destroy(effect);
        CookFood(r, recipe);
    }

    private void CookFood(string r, string recipe)
    {
        GameObject go = Instantiate(foodImage.gameObject, spritePosition.transform.position, transform.rotation, transform);
        foodImage.gameObject.name = FoodManager.FM_instance.currentRecipe;
        if (r == "GroundBeef" || r == "CookedHotdog" || r == "Tomato Sauce" || r == "Pasta" || r == "SousVide" || r == "Rice")
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
            foodImage.gameObject.AddComponent<FinishedFood>();
        }

        if (foodImage.gameObject.CompareTag("CookedIngredient"))
        {
            foodImage.gameObject.AddComponent<TakeIngedidnet>();
            foodImage.GetComponent<TakeIngedidnet>().IngredientName = "Cooked" + r;
        }
        if (foodImage.gameObject.name == "Nothing")
        {
            foodImage.gameObject.name = FoodManager.FM_instance.foodGameobjects[r].name;
        }
        foodImage.sprite = FoodManager.FM_instance.cookbook[r];
        print(foodImage.gameObject.name);
        foodImage.gameObject.transform.parent = newParent.transform;
        foodImage.GetComponent<SpriteRenderer>().sortingOrder = 16;
        //if(go)
        foodImage = go.GetComponent<SpriteRenderer>();
        spritePosition = foodImage.gameObject;
    }
}
