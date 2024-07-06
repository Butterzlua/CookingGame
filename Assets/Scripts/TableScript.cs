using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public bool active = true;
    public ParticleSystem Money_PS;
    private GameObject FoodThoughtBubble;
    public void MoneyDispense(int number)
    {
        Money_PS.Emit(number);
    }

    public void ActivateTable(bool activated)
    {
        if(activated)
        {
            FoodThoughtBubble.SetActive(false);
        }
    }
}
