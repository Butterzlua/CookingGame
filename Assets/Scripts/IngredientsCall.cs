using System.Collections;
using UnityEngine;

public class IngredientsCall : MonoBehaviour
{
    public GameObject[] organicPrefabs;
    public Transform pantry, converyorBelt;
    [SerializeField] private float cooldown = 5f;
    private bool canOrder = true;
    public float delay = 5f;
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && canOrder)
        {
            SpawnIngredients();
        }
        // else dialogue box saying wait for cooldown
    }

    private void SpawnIngredients()
    {
        for (int i = 0; i < organicPrefabs.Length; i++)
        {
            Instantiate(organicPrefabs[i], pantry.position + new Vector3(i * delay,0,0),Quaternion.identity,   converyorBelt);
            canOrder = false; 
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {     
        yield return new WaitForSeconds(cooldown);         
        canOrder = true;
    }
}
