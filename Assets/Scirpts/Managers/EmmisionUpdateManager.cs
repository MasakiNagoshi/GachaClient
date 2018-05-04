/////////////////////////////////////////////
//制作者　名越大樹
//EmmisionGachaシーンでの行進を管理するクラス
/////////////////////////////////////////////

public class EmmisionUpdateManager
{
    static EmmisionUpdateManager instance;
    public static EmmisionUpdateManager Instance { get { return instance; } }

    public EmmisionUpdateManager()
    {
        instance = this;
    }

    public void Update()
    {
         ScaleAniamtion();
         GetEffectUpdate();
    }

    void GetEffectUpdate()
    {
        if (GetEffectManager.Instace != null)
        {
            GetEffectManager.Instace.EffectUpdate();
        }
    }

    void ScaleAniamtion()
    {
       ScaleAnimationManager.Instance.AnimationUpdate();
    }
}
