﻿///////////////////////////////////////////
//制作者　名越大樹
//初めて入手したキャラクターの演出に関する基底クラス
///////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class GetEffectBase : MonoBehaviour
{
    int number;
    const string RATE_FILE = "Image/CharacterIllust/SSRRateImage/";
    const string CRY_FILE = "SE/Cry/";
    public GetEffectBase(){}

    public GetEffectBase(int dictionary)
    {
        number = dictionary;
    }

    /// <summary>
    /// キャラクターを表示させる処理
    /// </summary>
    /// <param name="number"></param>
    public virtual void ShowCharacter(int number)
    {
        Image image = GetEffectManager.Instace.CharacterImage;
        image.sprite = Resources.Load<Sprite>(RATE_FILE + number);
        image.color = Color.white;
        ScaleAnimationManager.Instance.CreateScaleAnimation(image.gameObject);
    }

    /// <summary>
    /// キャラクターの名前を表示させる処理
    /// </summary>
    /// <param name="number"></param>
    public virtual void ShowName(int number)
    {
        Text text = GetEffectManager.Instace.CharacterText;
        string name = DicitonaryName.Instance.GetName(number);
        text.text = name;
    }

    /// <summary>
    /// キャラクターのSEを再生させる処理
    /// </summary>
    /// <param name="number"></param>
    public virtual void PlayeCharacterCrySe(int number)
    {
        AudioSource audio = GetEffectManager.Instace.Audio;
        AudioClip clip = Resources.Load<AudioClip>(CRY_FILE + number);
        audio.clip = clip;
        audio.Play();
    }

    public virtual  void Ini()
    {
        GetEffectManager.Instace.ChangeCanvas();
    }

    public virtual void GetShowImage()
    {
        Image get = GetEffectManager.Instace.GetImage;
        get.color = Color.white;
        GetEffectManager.Instace.Audio.clip = Resources.Load<AudioClip>("SE/Effect/get");
        GetEffectManager.Instace.Audio.Play();
    }

    public virtual int GetNumber()
    {
        return number;
    }

    public virtual void EffectUpdate()
    {
    }

    public virtual bool IsClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
}