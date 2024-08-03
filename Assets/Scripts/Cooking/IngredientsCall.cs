using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsCall : MonoBehaviour
{
    public List<GameObject> organicPrefabs;
    public Transform pantry, converyorBelt;
    [SerializeField] private float cooldown = 5f;
    private bool canOrder = true;
    public float delay = 7.5f;
    [SerializeField] private Sprite HoverSprite;
    [SerializeField] private Sprite DefaultSprite;
    [SerializeField] private Sprite Cooldown1;
    [SerializeField] private Sprite Cooldown2;
    [SerializeField] private Sprite Cooldown3;
    [SerializeField] private SpriteRenderer spriteRender;
    private AudioSource sound;
    [SerializeField] private AudioClip Ticking, Click;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        converyorBelt = FoodManager.FM_instance.conveyorInAction.transform;
        sound.volume = 0.4f;
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && canOrder && !GameManager.instance.Paused)
        {
            SpawnIngredients();
        }
        // else dialogue box saying wait for cooldown
    }

    private void SpawnIngredients()
    {
        converyorBelt = FoodManager.FM_instance.conveyorInAction.transform;
        sound.PlayOneShot(Click);
        //for (int i = 0; i < organicPrefabs.Count; i++)
        //{
        //    GameObject tempFood = Instantiate(organicPrefabs[i], pantry.position + new Vector3(i * delay,0,0),Quaternion.identity,  converyorBelt);
        //    tempFood.GetComponent<SpriteRenderer>().sortingOrder = 16;
        //    canOrder = false;
        //}
        int i = 0;
        foreach(GameObject go in organicPrefabs)
        {
            GameObject tempFood = Instantiate(go, pantry.position + new Vector3(i * delay, 0, 0), Quaternion.identity);
            i++;
            tempFood.GetComponent<SpriteRenderer>().sortingOrder = 16;
            canOrder = false;
        }
            StartCoroutine(AnimationCooldown());
            StartCoroutine(Cooldown());
    }

    private IEnumerator AnimationCooldown()
    {
        sound.clip = (Ticking);
        sound.Play();
        spriteRender.sprite = Cooldown1;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown2;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown3;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown2;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown1;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown2;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown3;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown2;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown1;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = Cooldown2;
        yield return new WaitForSeconds(0.5f);
        spriteRender.sprite = DefaultSprite;
        sound.Stop();
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);      
        canOrder = true;
    }

    private void OnMouseEnter()
    {
        if (canOrder)
        {
            spriteRender.sprite = HoverSprite;
        }
    }

    private void OnMouseExit()
    {
        if (canOrder)
        {
            spriteRender.sprite = DefaultSprite;
        }
    }
}
