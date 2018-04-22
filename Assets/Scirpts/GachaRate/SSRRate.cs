﻿/////////////////////////////////////////
//制作者　名越大樹
//SSRレートのキャラクターのクラス
/////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class SSRRate : GachaRate
{
    public override void ChangeColor(string rate, bool duplication, int number, Button rateobj)
    {
        base.ChangeColor(rate, duplication, number, rateobj);
    }

    public override Button Instance(string rate,Button instanceobj, GameObject parent, bool duplication, string dictionary)
    {
        return base.Instance(rate,instanceobj, parent, duplication, dictionary);
    }
}