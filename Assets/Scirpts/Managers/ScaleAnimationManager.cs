using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimationManager
{
    List<ScaleAnimation> scaleAnimationList;
    static ScaleAnimationManager manager;
    public static ScaleAnimationManager Instance { get { return  manager; } }
    bool isUpdateAnimation = true;
    public bool IsUpdateAnimation { get { return IsUpdateAnimation; } set { IsUpdateAnimation = value; } }
    public ScaleAnimationManager()
    {
        manager = this;
        scaleAnimationList = new List<ScaleAnimation>();
    }

    public void CreateScaleAnimation(GameObject target,GachaRate rate)
    {
        ScaleAnimation scale = new ScaleAnimation(target,rate);
        scaleAnimationList.Add(scale);
    }

    public void CreateScaleAnimation(GameObject target)
    {
        ScaleAnimation scale = new ScaleAnimation(target);
        scaleAnimationList.Add(scale);
    }

    public void AnimationUpdate()
    {
        if(isUpdateAnimation)
        {
            foreach(ScaleAnimation scaleanimation in scaleAnimationList)
            {
                scaleanimation.AnimationUpdate();
            }
        }
    }

}
