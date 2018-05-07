/////////////////////////////////////////
//製作者　名越大樹　
//フェードのアニメーションに関するクラス
/////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class FadeAnimation : MonoBehaviour
{
    public enum FadeStatus
    {
        FadeIn,
        FadeOut,
        Complete,
    }

    [SerializeField]
    Image target;

    FadeStatus status;

    public FadeAnimation(FadeStatus set, Image target)
    {
        status = set;
    }

    public void UpdateAnimation()
    {
        switch (status)
        {
            case FadeStatus.FadeOut:
                FadeOutAnimation();
                break;
            case FadeStatus.FadeIn:
                FadeInAnimation();
                break;
            case FadeStatus.Complete:
                Debug.Log("終了");
                break;
        }

    }

    void Ini()
    {
        if (status == FadeStatus.FadeIn)
        {
            Color color = Color.white;
            color.a = 0.0f;
            target.color = color;
        }

        else
        {
            Color color = Color.white;
            color.a = 1.0f;
            target.color = color;
        }
    }

    void FadeInAnimation()
    {
        Color color = target.color;
        color.a += Time.deltaTime * 0.5f;
        Debug.Log(color.a);
        target.color = color;
        if (color.a >= 1.0f)
        {
            status = FadeStatus.Complete;
        }
    }

    void FadeOutAnimation()
    {
        Color color = target.color;
        color.a -= Time.deltaTime * 0.5f;
        Debug.Log(color.a);
        target.color = color;
        if (color.a <= 0.0f)
        {
            status = FadeStatus.Complete;
        }
    }
}
