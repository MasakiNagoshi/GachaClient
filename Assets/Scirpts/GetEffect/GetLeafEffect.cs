////////////////////////////////////////////////
//制作者　名越大樹
//草タイプの取得演出に関するクラス
////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;

public class GetLeafEffect : GetEffectBase
{
    List<float> effectTimer;
    int number;
    GameObject effect;
    const string FIRE_START_SE = "SE/Effect/fire01";
    const string EFFECT_LEAF_START = "Effect/LeafStart";
    const string EFFECT_LEAF_MARK = "Effect/LeafEffectDown";
    const string FIRE_MARK_SE = "SE/Effect/fire03";
    const string LEAF_MARKUP_EFFECT = "Effect/LeafEffectUp";
    const float INI_TIMER = 1.0f;
    const float TYPE_MARK_UP_TIMER = 5.0f;
    const float TYPE_MARK_DOWN_TIMER = 3.0f;
    const float SHOW_CHARACTER_TIMER = 1.0f;
    const float SHOW_NAME_TIMER = 2.0f;
    const float PLAY_SE_TIMER = 2.0f;
    const float GET_IMAGE_TIMER = 2.0f;
    const float FINISH_TIMER = 3.0f;
    const float MARK_DOWN_Y_POSITION = 70.0f;
    const float MARK_DOWN_Z_POSITION = 100.0f;
    const float MARK_UP_Z_POSITION = 200.0f;
    const float MARK_UP_Y_POSITION = -100.0f;
    const float START_EFFECT_OBJ_DESTROY_TIME = 5.0f;
    const float MARK_UP_EFFECT_OBJ_DESTROY_TIME = 10.0f;
    ActionList action = ActionList.Ini;
    enum ActionList
    {
        Ini,
        TypeMarkUp,
        TypeMarkDown,
        ShowCharacter,
        ShowName,
        PlaySe,
        GetImage,
        Finish,
    }

    public GetLeafEffect(int dictionary)
    {
        number = dictionary;
        GetEffectManager.Instace.EffectInstance = this;
        effectTimer = new List<float>();
        Ini();
    }

    public override void Ini()
    {
        base.Ini();
        IniTimer();
        int number = GetNumber();
        GameObject effet = Resources.Load<GameObject>(EFFECT_LEAF_START);
        GameObject instance = Instantiate(effet, Vector3.right * 10, Quaternion.identity);
        GetEffectManager.Instace.Audio.clip = Resources.Load<AudioClip>(FIRE_START_SE);
        GetEffectManager.Instace.Audio.Play();
        Destroy(instance, START_EFFECT_OBJ_DESTROY_TIME);
        GetEffectManager.Instace.BackGroundColorChange(GetEffectManager.BackGroundColor.Thunder);
        ScaleAnimationManager.Instance.CreateScaleAnimation(GetEffectManager.Instace.CharacterImage.gameObject);
    }

    void IniTimer()
    {
        effectTimer.Add(INI_TIMER);
        effectTimer.Add(TYPE_MARK_UP_TIMER);
        effectTimer.Add(TYPE_MARK_DOWN_TIMER);
        effectTimer.Add(SHOW_NAME_TIMER);
        effectTimer.Add(PLAY_SE_TIMER);
        effectTimer.Add(GET_IMAGE_TIMER);
        effectTimer.Add(FINISH_TIMER);
    }

    void MarkObj()
    {
        int number = GetNumber();
        GameObject fire = Resources.Load<GameObject>(EFFECT_LEAF_MARK);
        Vector3 pos = Vector3.up * MARK_DOWN_Y_POSITION;
        pos.z = MARK_DOWN_Z_POSITION;
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

    void TypeMarkUp()
    {
        GameObject instanceObj = Resources.Load<GameObject>(LEAF_MARKUP_EFFECT);
        Vector3 pos = Vector3.forward * MARK_UP_Z_POSITION;
        pos.y = MARK_UP_Y_POSITION;
        GameObject instance = Instantiate(instanceObj, pos, Quaternion.identity);
        Destroy(instance, MARK_UP_EFFECT_OBJ_DESTROY_TIME);
    }

    void Action()
    {
        switch (action)
        {
            case ActionList.TypeMarkUp:
                TypeMarkUp();
                break;
            case ActionList.TypeMarkDown:
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
