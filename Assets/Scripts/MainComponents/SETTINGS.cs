using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SETTINGS
{
    public const float defaultSpeed = 18f;
    public static string s_Speed = "speed";
    public static float speed
    {
        get
        {
            return PlayerPrefs.GetFloat(s_Speed, defaultSpeed);
        }
        set
        {
            PlayerPrefs.SetFloat(s_Speed, speed);
        }
    }
    
    public const int defaultTier = 0;
    public static string s_Tier = "tier";
    public static int tier
    {
        get
        {
            return PlayerPrefs.GetInt(s_Tier, tier);
        }
        set
        {
            PlayerPrefs.SetInt(s_Tier, tier);
        }
    }

    public const bool defaultExpansionBool = false;
    public static string s_expansionBought = "expansionBool";
    public static bool expansionBool
    {
        get
        {
            return PlayerPrefs.GetInt(s_expansionBought, defaultExpansionBool ? 1 : 0) !=0;
        }
        set
        {
            PlayerPrefs.SetInt(s_expansionBought, value ? 1 : 0);
        }
    }
}
