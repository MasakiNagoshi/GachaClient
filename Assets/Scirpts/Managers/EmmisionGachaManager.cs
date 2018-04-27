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
        GameObject obj = GameObject.Find(ObjectName.EMMISION_PARENT);
        emmisonCharacteresParent = obj;
        ScaleAnimationManager animation = new ScaleAnimationManager();
        EmmisionGachaIllustlation illust = new EmmisionGachaIllustlation(AttachRate.AttachGachaRate.GetGachaRate());
        AttachRate.AttachGachaRate.Gacha();
        SkipButton skip = new SkipButton();
    }
}
