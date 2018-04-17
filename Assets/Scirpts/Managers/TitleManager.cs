using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTTP;
using Protocol;

public class TitleManager
{
    public static TitleManager manager;

    public TitleManager()
    {
        manager = this;
        UserCheck();
    }

    void UserCheck()
    {
        if(PlayerPrefs.HasKey(NetWorkKey.USER_ID))
        {
            RequestLogin param = new RequestLogin();
            param.user_ip = PlayerPrefs.GetString(NetWorkKey.USER_ID);
            ApiClient.Instance.RequestLogin(param);
            //            ApiClient.Instance.
            //            SceneManagers.SceneLoad( SceneManagers.SceneName.Main);
        }

        else
        {
            SceneManagers.SceneLoad( SceneManagers.SceneName.CreateUser);
        }
    }

    void ResponseLogin(ResponseLogin response)
    {
        Debug.Log("e");
    }
}
