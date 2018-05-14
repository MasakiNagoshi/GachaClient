//////////////////////////////////////////
//製作者　名越大樹
//排出するキャラクターを管理するクラス
//////////////////////////////////////////

using UnityEngine;

public class EmmisionGachaManager
{
    static GameObject emmisonCharacteresParent;

    public static GameObject EmmisonCharacteresParent { get { return emmisonCharacteresParent; } }

    public EmmisionGachaManager()
    {
        Ini();
    }

    void Ini()
    {
        GameObject obj = GameObject.Find(ObjectName.EMMISION_PARENT);
        emmisonCharacteresParent = obj;
        ScaleAnimationManager animation = new ScaleAnimationManager();
        EmmisionGachaIllustlation illust = new EmmisionGachaIllustlation(AttachRate.AttachGachaRate.GetGachaRate());
        AttachRate.AttachGachaRate.Gacha();
        SkipButton skip = new SkipButton();
        CrySe cry = new CrySe();
    }
}
