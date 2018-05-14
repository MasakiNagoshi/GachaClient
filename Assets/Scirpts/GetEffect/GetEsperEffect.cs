/////////////////////////////////////////////////
//制作者　名越大樹
//エスパータイプの取得したときの演出に関するクラス
/////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;

public class GetEsperEffect : GetEffectBase
{
    List<float> effectTimer;
    int number;
    GameObject effect;
    const string ESPER_START_SE = "SE/Effect/fire01";
    const string EFFECT_ESPER_START = "Effect/EsperStart";
    const string EFFECT_ESPER_MARK = "Effect/EsperEffect";
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

    public GetEsperEffect(int dictionary)
    {
        number = dictionary;
        Debug.Log("エスパーの演出開始");
        GetEffectManager.Instace.EffectInstance = this;
        effectTimer = new List<float>();
        Ini();
    }

    public override void Ini()
    {
        base.Ini();
        IniTimer();
        int number = GetNumber();
        GameObject effet = Resources.Load<GameObject>(EFFECT_ESPER_START);
        GameObject instance = Instantiate(effet, Vector3.zero, Quaternion.identity);
        GetEffectManager.Instace.Audio.clip = Resources.Load<AudioClip>(ESPER_START_SE);
        GetEffectManager.Instace.Audio.Play();
        Destroy(instance, 10);
        GetEffectManager.Instace.BackGroundColorChange(GetEffectManager.BackGroundColor.Esper);
        ScaleAnimationManager.Instance.CreateScaleAnimation(GetEffectManager.Instace.CharacterImage.gameObject);
    }

    void IniTimer()
    {
        effectTimer.Add(1);
        effectTimer.Add(5);
        effectTimer.Add(1);
        effectTimer.Add(2);
        effectTimer.Add(2);
        effectTimer.Add(3);
    }

    void MarkObj()
    {
        int number = GetNumber();
        GameObject fire = Resources.Load<GameObject>(EFFECT_ESPER_MARK);
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
