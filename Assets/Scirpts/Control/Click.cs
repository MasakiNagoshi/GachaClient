////////////////////////////////////////////////
//制作者　名越大樹
//クリックしたときのSEに関するクラス
/////////////////////////////////////////////////

using UnityEngine;

public class Click : MonoBehaviour
{
    static Click instance;
    static AudioSource audio;
    MonoBehaviour mono;
    const string CLICK_SE_FILE = "SE/Click/ClickSe";
    const string CLICK_SE_OBJ = "ClickSE";
    public static Click Instance
    {
        get
        {
            if (instance == null && audio == null)
            {
                var click = new Click();
            }
            return instance;
        }
    }

    public Click()
    {
        instance = this;
        var obj = new GameObject(CLICK_SE_OBJ);
        obj.AddComponent<AudioSource>();
        DontDestroyOnLoad(obj);
        audio = obj.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>(CLICK_SE_FILE);
    }

    public void PlaySe()
    {
        audio.Play();
    }

    public void ChangeSe(AudioClip clip)
    {
        audio.clip = clip;
    }
}
