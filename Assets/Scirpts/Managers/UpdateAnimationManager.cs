////////////////////////////////////////////////////////////////////
//制作者　名越大樹
//通信時のエラーのUIを表示する際のアニメーションを管理するクラス
/////////////////////////////////////////////////////////////////

using UnityEngine;

public class ErrorUpdateAnimationManager : MonoBehaviour
{
    static ErrorUpdateAnimationManager instance;
    const string UPDATE_ANIMATION_OBJ = "UpdateAnimationObj";
    public static ErrorUpdateAnimationManager Instance
    {
        get
        {
            var manager = new GameObject(UPDATE_ANIMATION_OBJ);
            instance = manager.AddComponent<ErrorUpdateAnimationManager>();
            return instance;
        }
    }
    public void AnimationStart()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        ScaleAnimationManager.Instance.AnimationUpdate();
    }
}
