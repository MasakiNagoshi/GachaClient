using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTTP;
using Protocol;
public class AllGetNumbers : MonoBehaviour
{
    public static  void AllGetNumber()
    {
        RequestGetDictionary param = new RequestGetDictionary();
        param.user_id = PlayerPrefs.GetString("id");
        Debug.Log(PlayerPrefs.GetString("id"));
        ApiClient.Instance.RequestGetDictionary(param);
    }
}
