////////////////////////////////////////
//製作者　名越大樹
//ノーマルレートのキャラクターのクラス
////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class NRate : GachaRate
{
    Button character;

    public override Button Instance(string rate,Button instanceobj, GameObject parent, bool duplication, string dictionary)
    {
        character =  base.Instance(rate,instanceobj, parent, duplication, dictionary);
        return null;
    }

    public override void ChangeColor(string rate,bool duplication,int number,Button rateobj)
    {

        base.ChangeColor(rate,duplication,number,rateobj);
        /*
        if (duplication)
        {
            obj.color = Color.black;
        }
        else
        {
            obj.color = Color.red;
        }
        */
    }
}
