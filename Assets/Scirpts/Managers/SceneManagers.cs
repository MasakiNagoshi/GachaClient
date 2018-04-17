using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagers
{
    public enum SceneName
    {
        Title,
        Main,
        Dictionary,
        CreateUser,
        LoginPresent,
        EmmisionGacha,
    }

    public static void SceneLoad(SceneName name)
    {
        switch (name)
        {
            case SceneName.Main:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Gacha");
                break;
            case SceneName.CreateUser:
                UnityEngine.SceneManagement.SceneManager.LoadScene("CreateUser");
                break;
            case SceneName.LoginPresent:
                UnityEngine.SceneManagement.SceneManager.LoadScene("LoginPresent");
                break;
            case SceneName.EmmisionGacha:
                UnityEngine.SceneManagement.SceneManager.LoadScene("EmmisionGacha");
                break;
        }

    }
}
