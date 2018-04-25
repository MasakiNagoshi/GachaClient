///////////////////////////////////////////
//制作者　名越大樹
//スケールのアニメーションに関するクラス
///////////////////////////////////////////

using UnityEngine;

public class ScaleAnimation
{
    Vector3 defalutScale;//初期サイズ
    GameObject targetObj;//アニメーションさせるオブジェクト
    bool isAnimation = true;//アニメーションが終わったかどうか
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
