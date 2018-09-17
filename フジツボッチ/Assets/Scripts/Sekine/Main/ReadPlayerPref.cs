////////////////////////////////////
//製作者　名越大樹
//クラス　PlayerPrefを使うクラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerPref : MonoBehaviour
{
    public static bool GetHasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static string GetStringKey(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public static int GetIntKey(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static float GetFloatKey(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public static void SetIntKey(string key, int value)
    {
        PlayerPrefs.SetInt(key,value);
    }

    public static void SetFloatKey(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static void SetStringKey(string key, string value)
    {
        PlayerPrefs.SetString(key,value);
    }
}
