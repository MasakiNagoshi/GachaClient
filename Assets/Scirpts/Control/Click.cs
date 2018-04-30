using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    static Click instance;
    static AudioSource audio;
    MonoBehaviour mono;
    
    public static Click Instance
    {
        get
        {
            if (instance == null && audio == null)
            {
                Debug.Log("hage");
                var click = new Click();
            }
            return instance;
        }
    }

    public Click()
    {
        instance = this;
        var obj = new GameObject("ClickSE");
        obj.AddComponent<AudioSource>();
        DontDestroyOnLoad(obj);
        audio = obj.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Click/ClickSe");
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
