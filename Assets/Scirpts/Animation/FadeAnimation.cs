/////////////////////////////////////////
//製作者　名越大樹　
//フェードのアニメーションに関するクラス
/////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation
{
    public enum FadeStatus
    {
        FadeIn,
        FadeOut,
    }

    FadeStatus status;

    public FadeAnimation(FadeStatus set)
    {
        status = set;
    }

    public void UpdateAnimation()
    {
       
    }

    void FadeOutAnimation()
    {

    }

    void FadeInAnimation()
    {

    }
}
