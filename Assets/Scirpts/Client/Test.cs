using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTTP;
using Protocol;

public class Test : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("id"))
        {
            RequestCreateUser param = new RequestCreateUser();
            param.user_name = "hoge";
            ApiClient.Instance.RequestCreateUser(param);
        }
        else
        {
            Debug.Log("a");
            Debug.Log(PlayerPrefs.GetString("id"));
            Debug.Log(PlayerPrefs.GetString("name"));
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*
            RequestLogin param = new RequestLogin();
            param.user_ip = PlayerPrefs.GetString("id");
            ApiClient.Instance.RequestLogin(param);
            */
            RequestGetDictionary param = new RequestGetDictionary();
            param.user_id = PlayerPrefs.GetString("id");
            ApiClient.Instance.RequestGetDictionary(param);
        }
    }
}
