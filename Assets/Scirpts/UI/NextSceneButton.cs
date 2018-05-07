///////////////////////////////////////
//制作者　名越大樹
//次のシーンへ遷移するクラス
///////////////////////////////////////

using UnityEngine;

public class NextSceneButton : MonoBehaviour
{
    [SerializeField]
    SceneManagers.SceneName status;

    public void NextScene()
    {
        SceneManagers.SceneLoad(status);
    }
}
