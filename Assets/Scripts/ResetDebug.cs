using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ResetDebug : MonoBehaviour
{
    [SerializeField] private GameObject boughtUpgrade;
    [SerializeField] private GameObject upgradeTier;
    private void OnMouseUpAsButton()
    {
        FoodManager.FM_instance.CutTime = 0;
        FoodManager.FM_instance.CookMultiplier = 0;
        boughtUpgrade.GetComponent<BuyExpansion>().BoughtUpgrade = false;
        upgradeTier.GetComponent<BuyWalkSpeed>().UpgradeTier = 0;
    }
}
