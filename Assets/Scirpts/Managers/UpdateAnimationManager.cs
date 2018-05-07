using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimationManager : MonoBehaviour
{
    static UpdateAnimationManager instance;
    public static UpdateAnimationManager Instance
    {
        get
        {
                var manager = new GameObject("UpdateAnimationObj");
                instance = manager.AddComponent<UpdateAnimationManager>();
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
