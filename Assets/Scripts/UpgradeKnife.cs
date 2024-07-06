using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeKnife : MonoBehaviour
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
        PlayerPrefs.SetFloat("CuttingTime", FoodManager.FM_instance.CutTime);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("CuttingTime"))
        {
            FoodManager.FM_instance.CutTime = PlayerPrefs.GetFloat("CuttingTime");
            if (FoodManager.FM_instance.CutTime == 0)
            {
                FoodManager.FM_instance.CutTime = 6;
            }
            if (FoodManager.FM_instance.CutTime <= 1)
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
            FoodManager.FM_instance.CutTime -= 0.25f;
            if(FoodManager.FM_instance.CutTime <= 1)
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
