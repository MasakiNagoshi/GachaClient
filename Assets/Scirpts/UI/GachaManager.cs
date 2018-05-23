/////////////////////////////////////////////////////
//制作者　名越大樹
//ガチャシーンを管理するクラス
/////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class GachaManager
{
    const string CLICK_SE_FILE = "SE/Click/ClickSe";

    public GachaManager(Button instance)
    {
        Ini(instance);
    }

    void Ini(Button instance)
    {
        GameObject parent = GameObject.Find(ObjectName.CANVAS);
        CanvasManager.Canvas = parent;
        EmmisionCharacterRateManager manager = new EmmisionCharacterRateManager(instance);
        Click.Instance.ChangeSe(Resources.Load<AudioClip>(CLICK_SE_FILE));
    }
}
