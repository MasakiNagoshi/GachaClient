/////////////////////////////////////////
//制作者　名越大樹
//排出キャラクターを管理するクラス
/////////////////////////////////////////

using UnityEngine.UI;

public class EmmisionCharacterRateManager
{
    static Button rateObj;

    public static Button RateObj { get { return rateObj; } }

    public EmmisionCharacterRateManager(Button rate)
    {
        rateObj = rate;
    }
}
