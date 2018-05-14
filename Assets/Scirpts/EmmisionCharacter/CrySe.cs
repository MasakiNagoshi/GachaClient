////////////////////////////////////////////
//制作者　名越大樹
//鳴き声を再生するクラス
////////////////////////////////////////////

using UnityEngine;

public class CrySe
{
    static CrySe instance;
    AudioSource audio;
    GameObject obj;
    const string CRY_SE_OBJ = "CrySe";

    public static CrySe Instance
    {
        get
        {
            if (instance == null)
            {
                CrySe cryse = new CrySe();
            }
            return instance;
        }
    }

    public CrySe()
    {
        instance = this;
        obj = new GameObject(CRY_SE_OBJ);
        audio = obj.AddComponent<AudioSource>();
    }

    public void PlaySe()
    {
        audio.Play();
    }

    public void ChangeSe(AudioClip se)
    {
        audio.clip = se;
    }
}
