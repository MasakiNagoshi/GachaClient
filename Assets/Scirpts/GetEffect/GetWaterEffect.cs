﻿using UnityEngine;
using System.Collections.Generic;

public class GetWaterEffect : GetEffectBase
{
    List<float> effectTimer;
    int number;
    GameObject effect;
    const string WATER_START_SE = "SE/Effect/babule01";
    const string EFFECT_WATER_START = "Effect/BabuleStart";
    const string EFFECT_WATER_MARK = "Effect/BabuleEffect";
    const string FIRE_MARK_SE = "SE/Effect/fire03";
    ActionList action = ActionList.Ini;

    enum ActionList
    {
        Ini,
        TipeMark,
        ShowCharacter,
        ShowName,
        PlaySe,
        GetImage,
        Finish,
        Delete,
    }

    public GetWaterEffect(int dictionary)
    {
        number = dictionary;
        Debug.Log("水の演出開始");
        GetEffectManager.Instace.EffectInstance = this;
        Debug.Log(GetEffectManager.Instace.EffectInstance);
        effectTimer = new List<float>();
        Ini();
    }

    public override void Ini()
    {
        base.Ini();
        IniTimer();
        int number = GetNumber();
        GameObject effet = Resources.Load<GameObject>(EFFECT_WATER_START);
        GameObject instance = Instantiate(effet, Vector3.down, Quaternion.identity);
        GetEffectManager.Instace.Audio.clip = Resources.Load<AudioClip>(WATER_START_SE);
        GetEffectManager.Instace.Audio.Play();
        Destroy(instance, 10);
        GetEffectManager.Instace.BackGroundColorChange(GetEffectManager.BackGroundColor.Ice);
        ScaleAnimationManager.Instance.CreateScaleAnimation(GetEffectManager.Instace.CharacterImage.gameObject);
    }

    void IniTimer()
    {
        effectTimer.Add(1);
        effectTimer.Add(3);
        effectTimer.Add(1);
        effectTimer.Add(2);
        effectTimer.Add(2);
        effectTimer.Add(3);
    }

    void MarkObj()
    {
        int number = GetNumber();
        GameObject fire = Resources.Load<GameObject>(EFFECT_WATER_MARK);
        Vector3 pos = GetEffectManager.Instace.TipeMrakPostion;
        GameObject effectinstance = Instantiate(fire, pos, Quaternion.identity);
        GetEffectManager.Instace.Audio.clip = Resources.Load<AudioClip>(FIRE_MARK_SE);
        GetEffectManager.Instace.Audio.Play();
        effect = effectinstance;
        effectinstance.transform.Rotate(-90, 0, 0);
    }

    void ShowCharacter()
    {
        base.ShowCharacter(number);
    }

    void GetImage()
    {
        base.GetShowImage();
    }

    void ShowName()
    {
        base.ShowName(number);
    }


    void PlayCharacterSe()
    {
        base.PlayeCharacterCrySe(number);
    }

    void Finish()
    {
        Destroy(effect);
        GetEffectManager.Instace.Finish();

    }
    public override void EffectUpdate()
    {
        bool result = base.IsClick();
        if (result)
        {
            Finish();
        }
        if (action == ActionList.Finish)
        {
            return;
        }

        effectTimer[0] -= Time.deltaTime;
        if (effectTimer[0] <= 0.0f)
        {
            effectTimer.RemoveAt(0);
            Action();
        }
    }

    void Action()
    {
        switch (action)
        {
            case ActionList.TipeMark:
                MarkObj();
                break;
            case ActionList.ShowCharacter:
                ShowCharacter();
                break;
            case ActionList.ShowName:
                ShowName();
                break;
            case ActionList.PlaySe:
                PlayCharacterSe();
                break;
            case ActionList.GetImage:
                GetImage();
                break;
        }
        action++;
    }
}
