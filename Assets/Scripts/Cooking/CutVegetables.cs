using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutVegetables : MonoBehaviour
{
    private AudioSource sound;
    [SerializeField] private Animator knife;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        knife = GetComponentInChildren<Animator>();
    }

    private IEnumerator Cut(GameObject food, float time)
    {
        sound.Play();
        knife.SetBool("Cutting", true);
        knife.speed = 3 / time;
        sound.pitch = 3 / time;
        food.GetComponent<TakeIngedidnet>().Cutting = true;
        food.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + -0.04f);
        yield return new WaitForSeconds(time);
        food.GetComponent<TakeIngedidnet>().Cutting = false;
        food.tag = "Untagged";
        food.GetComponent<SpriteRenderer>().sprite = food.GetComponent<TakeIngedidnet>().cutSprite;
        food.GetComponent<TakeIngedidnet>().IngredientName = "Cut" + food.GetComponent<TakeIngedidnet>().IngredientName;
        sound.Stop();
        knife.SetBool("Cutting", false);
        if(food.GetComponent<TakeIngedidnet>().IngredientName == "CutChicken")
        {
            Instantiate(food, new Vector3(transform.position.x, transform.position.y, transform.position.z -0.04f), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cuttable"))
        {
            sound.volume = 1;
            StartCoroutine (Cut(collision.gameObject, FoodManager.FM_instance.CutTime));
            
        }
    }
}
