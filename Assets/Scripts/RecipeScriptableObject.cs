using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Cooking Items/Recipe")]
public class RecipeScriptableObject : ScriptableObject
{
    public int pageNumber;
    public string recipeName;
    public string[] ingredientNames;
    public Sprite[] ingredientSprites;
    public Sprite recipeSprite2D;
    public GameObject recipe3D;
    public float cost;
    public float cookingTime;
    public Vector2 SaltAndPepper;
}
