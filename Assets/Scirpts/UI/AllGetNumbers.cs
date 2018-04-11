using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTTP;
using Protocol;
public class AllGetNumbers : MonoBehaviour
{
    public static  void AllGetNumber()
    {
        RequestGetAllNumbers param = new RequestGetAllNumbers();
        param.user_id = PlayerPrefs.GetString("id");
        Debug.Log(PlayerPrefs.GetString("id"));
        ApiClient.Instance.RequestGetAllNumbers(param);
    }
}
