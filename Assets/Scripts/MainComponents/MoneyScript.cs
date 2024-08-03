using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public static MoneyScript MS_Instance;
    private Text uiText;
    public float Money, minimumTips = 5f, maximumTips = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        if (MS_Instance == null)
        {
            MS_Instance = this;
        }
        else
        {
            Destroy(MS_Instance.gameObject);
        }

        if (PlayerPrefs.HasKey("Money"))
        {
            Money = PlayerPrefs.GetFloat("Money");
        }
        else
        {
            Money = 0;
        }
    }

    void Start()
    {
        uiText = this.GetComponentInChildren<Text>();
        updateMoneyCounter();
    }

    public void GiveMoney(float Amount, string Recipe)
    {
        //Money += Amount;

        if (FoodManager.FM_instance.SnP_Table[Recipe] == new Vector2Int(FoodManager.FM_instance.CurrentSaltAmount, FoodManager.FM_instance.CurrentPepperAmount))
        {
            StarManager.SM_Instance.updateStar(Random.Range(0.5f, 0.9f));
            Money += Random.Range(minimumTips, maximumTips);
        }
        else
        {
            StarManager.SM_Instance.updateStar(Random.Range(0.5f, 1f));
            Money += Amount;
        }

        updateMoneyCounter();
    }

    public void updateMoneyCounter()
    {
        uiText.text = "Restaurant Funds: $" + Money.ToString("F2");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Money", Money);
    }
}
