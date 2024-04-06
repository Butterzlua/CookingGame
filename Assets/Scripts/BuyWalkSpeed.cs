using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuyWalkSpeed : MonoBehaviour
{
    public int UpgradeTier, speed;
    [SerializeField] private Sprite HoverSprite;
    [SerializeField] private Sprite DefaultSprite;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private SpriteRenderer spriteRender2;
    [SerializeField] private Sprite BoughtSprite, DefaultSprites;
    [SerializeField] private NavMeshAgent ChefSpeed;
    [SerializeField] private NavMeshAgent WaiterSpeed;
    private AudioSource sound;
    [SerializeField] AudioClip Wrong, Click;
    // Start is called before the first frame update
    private void OnApplicationQuit()
    {
        SetPlayerPres();
    }

    private void SetPlayerPres()
    {
        print("player prefs set");
        PlayerPrefs.SetFloat("ChefSpeed", ChefSpeed.speed);
        PlayerPrefs.SetFloat("WaiterSpeed", WaiterSpeed.speed);
        PlayerPrefs.SetInt("UpgradeTier", UpgradeTier);
        PlayerPrefs.Save();

        SetSpeed();
        if (PlayerPrefs.HasKey("UpgradeTier"))
        {
            UpgradeTier = PlayerPrefs.GetInt("UpgradeTier");
            //IncreaseSpeed();
            if (PlayerPrefs.GetInt("UpgradeTier") >= 5)
            {
                spriteRender2.sprite = BoughtSprite;
                spriteRender.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                spriteRender2.sprite = DefaultSprites;
                spriteRender.enabled = true;
                GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void Start()
    {
        //print(PlayerPrefs.GetInt("UpgradeTier"));
        sound = GetComponent<AudioSource>();
        SetSpeed();
        if(PlayerPrefs.HasKey("UpgradeTier"))
        {
            UpgradeTier = PlayerPrefs.GetInt("UpgradeTier");
            //IncreaseSpeed();
            if (PlayerPrefs.GetInt("UpgradeTier") >= 5)
            {
                spriteRender2.sprite = BoughtSprite;
                spriteRender.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }        

    private void SetSpeed()
    {
        ChefSpeed.speed = PlayerPrefs.GetFloat("ChefSpeed");
        WaiterSpeed.speed = PlayerPrefs.GetFloat("WaiterSpeed");
    }

    private void IncreaseSpeed()
    {

        ChefSpeed.speed += 2;
        WaiterSpeed.speed += 2;
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
            IncreaseSpeed();
            UpgradeTier += 1;
            PlayerPrefs.SetInt("UpgradeTier", UpgradeTier);
            if (UpgradeTier >= 5)
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
