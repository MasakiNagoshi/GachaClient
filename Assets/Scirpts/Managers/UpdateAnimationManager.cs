

using UnityEngine;

public class ErrorUpdateAnimationManager : MonoBehaviour
{
    static ErrorUpdateAnimationManager instance;

    public static ErrorUpdateAnimationManager Instance
    {
        get
        {
            var manager = new GameObject("UpdateAnimationObj");
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
