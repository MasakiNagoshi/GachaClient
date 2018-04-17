using System.Collections;
using System.Collections.Generic;
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
