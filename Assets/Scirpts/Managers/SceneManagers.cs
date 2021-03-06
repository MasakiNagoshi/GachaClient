﻿//////////////////////////////////
//制作者　名越大樹
//シーン遷移全他を管理するクラス
//////////////////////////////////

public class SceneManagers
{
    static SceneName scene;
    const string TITLE_SCENE = "Title";
    const string GACHA_SCENE = "Gacha";
    const string CREATE_USER_SCENE = "CreateUser";
    const string LOGIN_PRESENT_SCENE = "LoginPresent";
    const string EMMISION_GACHA_SCENE = "EmmisionGacha";
    const string DICTIONARY_SCENE = "Dictionary";
    const string STONE_SHOPPING_SCENE = "Stone";
    public enum SceneName
    {
        Title,
        Main,
        Dictionary,
        CreateUser,
        LoginPresent,
        EmmisionGacha,
        Shopping,
    }

    public static SceneName Scene { get { return scene; } }


    public static void SceneLoad(SceneName name)
    {
        scene = name;
        switch (name)
        {
            case SceneName.Title:
                UnityEngine.SceneManagement.SceneManager.LoadScene(TITLE_SCENE);
                break;
            case SceneName.Main:
                UnityEngine.SceneManagement.SceneManager.LoadScene(GACHA_SCENE);
                break;
            case SceneName.CreateUser:
                UnityEngine.SceneManagement.SceneManager.LoadScene(CREATE_USER_SCENE);
                break;
            case SceneName.LoginPresent:
                UnityEngine.SceneManagement.SceneManager.LoadScene(LOGIN_PRESENT_SCENE);
                break;
            case SceneName.EmmisionGacha:
                UnityEngine.SceneManagement.SceneManager.LoadScene(EMMISION_GACHA_SCENE);
                break;
            case SceneName.Dictionary:
                UnityEngine.SceneManagement.SceneManager.LoadScene(DICTIONARY_SCENE);
                break;
            case SceneName.Shopping:
                UnityEngine.SceneManagement.SceneManager.LoadScene(STONE_SHOPPING_SCENE);
                break;
        }
    }
}
