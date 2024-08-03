using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCooking : MonoBehaviour
{
    [SerializeField] private Sprite HoverSprite;
    [SerializeField] private Sprite DefaultSprite;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private SpriteRenderer spriteRender2;
    [SerializeField] private Sprite BoughtSprite;
    private AudioSource sound;
    [SerializeField] AudioClip Wrong, Click;
    // Start is called before the first frame update
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("CookMultiplier", FoodManager.FM_instance.CookMultiplier);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("CuttingTime"))
        {
            FoodManager.FM_instance.CookMultiplier = PlayerPrefs.GetFloat("CookMultiplier");
            if (FoodManager.FM_instance.CookMultiplier == 0)
            {
                FoodManager.FM_instance.CookMultiplier = 1;
            }
            if (FoodManager.FM_instance.CookMultiplier >= 1.25)
            {
                spriteRender2.sprite = BoughtSprite;
                spriteRender.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    private void OnMouseEnter()
    {
        spriteRender.sprite = HoverSprite;
    }

    private void OnMouseExit()
    {
        spriteRender.sprite = DefaultSprite;
    }

    private void OnMouseUp()
    {
        if (MoneyScript.MS_Instance.Money >= 15.00)
        {
            sound.volume = 0.65f;
            sound.pitch = 1.25f;
            sound.PlayOneShot(Click);
            MoneyScript.MS_Instance.Money -= 15;
            MoneyScript.MS_Instance.updateMoneyCounter();
            FoodManager.FM_instance.CookMultiplier += 0.05f; ;
            if (FoodManager.FM_instance.CookMultiplier >= 1.25f)
            {
                spriteRender2.sprite = BoughtSprite;
                spriteRender.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            sound.volume = 0.9f;
            sound.pitch = 1f;
            sound.PlayOneShot(Wrong);
        }
    }
}
