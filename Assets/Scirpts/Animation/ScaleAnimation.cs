using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation
{
    Vector3 defalutScale;
    GameObject targetObj;
    bool isAnimation = true;
    GachaRate gachaRate = null;

    public ScaleAnimation(GameObject target, GachaRate rate)
    {
        gachaRate = rate;
        defalutScale = target.transform.localScale;
        target.transform.localScale = Vector3.zero;
        targetObj = target;
        isAnimation = true;
    }

    public ScaleAnimation(GameObject target)
    {
        defalutScale = target.transform.localScale;
        target.transform.localScale = Vector3.zero;
        targetObj = target;
        isAnimation = true;
    }

    public void AnimationUpdate()
    {
        if(!isAnimation)
        {
            return;
        }
        Vector3 scale = targetObj.transform.localScale;
        scale.x += Time.deltaTime;
        scale.y += Time.deltaTime;
        targetObj.transform.localScale = scale;
        if (defalutScale.x <= scale.x)
        {
            isAnimation = false;
            InstanceEffect();
        }
    }

    void InstanceEffect()
    {
        if (gachaRate != null)
        {
            gachaRate.EffectAction();
        }
    }
}
