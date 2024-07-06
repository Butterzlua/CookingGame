using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyExpansion : MonoBehaviour
{
    public bool BoughtUpgrade;
    [SerializeField] private Sprite HoverSprite;
    [SerializeField] private Sprite DefaultSprite;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private SpriteRenderer spriteRender2;
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject Table1;
    [SerializeField] private GameObject Table2;
    [SerializeField] private Sprite BoughtSprite;
    [SerializeField] private Sprite Normal;
    private AudioSource sound;
    [SerializeField] AudioClip Wrong, Click;

    // Start is called before the first frame update
    private void OnApplicationQuit()
    {
        //PlayerPrefs.SetInt("ExpansionBought", BoughtUpgrade ? 1 : 0);
        if (BoughtUpgrade)
            PlayerPrefs.SetInt("ExpansionBought", 1);
        else
            PlayerPrefs.SetInt("ExpansionBought", 0);

        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (SETTINGS.expansionBool == true)
            {
            barrier.SetActive(false);
            Table1.SetActive(true);
            Table2.SetActive(true);
            spriteRender2.sprite = BoughtSprite;
            spriteRender.enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            }
        int Boughtexpan = PlayerPrefs.GetInt("ExpansionBought", 0);
        if (Boughtexpan == 0)
        {
           // print("equals 0");
            barrier.SetActive(true);
            Table1.SetActive(false);
            Table2.SetActive(false);
            spriteRender2.sprite = Normal;
            spriteRender.enabled = true;
            GetComponent<BoxCollider>().enabled = true;
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
        if (MoneyScript.MS_Instance.Money >= 120.00)
        {
            sound.volume = 0.65f;
            sound.pitch = 1.25f;
            sound.PlayOneShot(Click);
            SETTINGS.expansionBool = true;
            barrier.SetActive(false);
            Table1.SetActive(true);
            Table2.SetActive(true);
            MoneyScript.MS_Instance.Money -= 120;
            MoneyScript.MS_Instance.updateMoneyCounter();
            BoughtUpgrade = true;
            spriteRender2.sprite = BoughtSprite;
            spriteRender.enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            sound.volume = 0.9f;
            sound.pitch = 1f;
            sound.PlayOneShot(Wrong);
        }
    }
}
