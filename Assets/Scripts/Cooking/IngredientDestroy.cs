using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDestroy : MonoBehaviour
{
    [SerializeField] bool Silent;
    private AudioSource sound;

    private void Start()
    {
        if (!Silent)
        {
            sound = GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<TakeIngedidnet>())
        {
            Destroy(collision.gameObject);
            if (!Silent)
            {
                SoundPlay();
            }
        } else if(collision.GetComponent<RenewableIngredient>())
        {
            collision.transform.position = collision.GetComponent<RenewableIngredient>().originalPosition;
        }
    }

    public void SoundPlay()
    {
        sound.Play();
    }
}
