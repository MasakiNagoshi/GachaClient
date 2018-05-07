/////////////////////////////////////////////////
//制作者　名越大樹
//スケールアニメーションを管理するクラス
/////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimationManager
{
    List<ScaleAnimation> scaleAnimationList;
    static ScaleAnimationManager manager;
    bool isUpdateAnimation = true;

    public bool IsUpdateAnimation { get { return IsUpdateAnimation; } set { IsUpdateAnimation = value; } }
    public static ScaleAnimationManager Instance {
        get {
            if (manager == null)
            {
                ScaleAnimationManager instance = new ScaleAnimationManager();
            }
            return manager; } }

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

    public void CreateScaleAnimation(GameObject target, float speed)
    {
        ScaleAnimation scale = new ScaleAnimation(target, speed);
        scaleAnimationList.Add(scale);
    }

    /// <summary>
    /// 毎回更新する処理
    /// </summary>
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
