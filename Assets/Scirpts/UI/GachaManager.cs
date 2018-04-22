/////////////////////////////////////////////////////
//制作者　名越大樹
//ガチャシーンを管理するクラス
/////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class GachaManager
{
    public GachaManager(Button instance)
    {
        Ini(instance);
    }

    void Ini(Button instance)
    {
        GameObject parent = GameObject.Find(ObjectName.CANVAS);
        CanvasManager.Canvas = parent;
        RateManager manager = new RateManager(instance);
    }
}
