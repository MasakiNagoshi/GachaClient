
using UnityEngine;

public class CrySe
{
    static CrySe instance;
    AudioSource audio;
    GameObject obj;
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
        obj = new GameObject("CrySe");
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
