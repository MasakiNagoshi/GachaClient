﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFireEffect : GetEffectBase
{
    List<float> effectTimer;
    int number;
    GameObject effect;
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
    ActionList action = ActionList.Ini;
    public GetFireEffect(int dictionary)
    {
        number = dictionary;
        Debug.Log("炎の演出開始");
        GetEffectManager.Instace.EffectInstance = this;
        Debug.Log(GetEffectManager.Instace.EffectInstance);
        effectTimer = new List<float>();
        Ini();
    }

    public override void Ini()
    {
        base.Ini();
        effectTimer.Add(1);
        effectTimer.Add(3);
        effectTimer.Add(1);
        effectTimer.Add(2);
        effectTimer.Add(2);
        effectTimer.Add(3);
        int number = GetNumber();
        GameObject effet = Resources.Load<GameObject>("Effect/FireStart");
        GameObject instance = Instantiate(effet,Camera.main.transform.position,Quaternion.identity);
        Destroy(instance, 3);
        GetEffectManager.Instace.BackGroundColorChange(GetEffectManager.BackGroundColor.Fire);
        ScaleAnimationManager.Instance.CreateScaleAnimation(GetEffectManager.Instace.CharacterImage.gameObject);
    }

    void MarkObj()
    {
        int number = GetNumber();
        GameObject fire = Resources.Load<GameObject>("Effect/FireEffect");
        Vector3 pos = GetEffectManager.Instace.TipeMrakPostion;
        GameObject effectinstance = Instantiate(fire, pos, Quaternion.identity);
        effect = effectinstance;
        effectinstance.transform.Rotate(-90, 0, 0);
    }

    void ShowCharacter()
    {
        base.ShowCharacter(number);
    }

    void GetImage()
    {
       Image get = GetEffectManager.Instace.GetImage;
        get.color = Color.white;
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
            Debug.Log("クリックしたよ");
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
            case ActionList.Finish:
                // Finish();
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
