//////////////////////////////////
//制作者　名越大樹
//シーン遷移全他を管理するクラス
//////////////////////////////////

public class SceneManagers
{
    const string TITLE_SCENE = "Title";
    const string GACHA_SCENE = "Gacha";
    const string CREATE_USER_SCENE = "CreateUser";
    const string LOGIN_PRESENT_SCENE = "LoginPresent";
    const string EMMISION_GACHA_SCENE = "EmmisionGacha";
    const string DICTIONARY_SCENE = "Dictionary";

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
        }
    }
}
