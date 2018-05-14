///////////////////////////////////////////////
//制作者　名越大樹
//Titleシーン状を管理するクラス
///////////////////////////////////////////////

using UnityEngine;
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
        if (PlayerPrefs.HasKey(NetWorkKey.USER_ID))
        {
            RequestLogin param = new RequestLogin();
            param.user_ip = PlayerPrefs.GetString(NetWorkKey.USER_ID);
            ApiClient.Instance.RequestLogin(param);
        }

        else
        {
            SceneManagers.SceneLoad(SceneManagers.SceneName.CreateUser);
        }
    }
}
