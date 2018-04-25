using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetEffectManager
{
    static GetEffectManager instance;
    public static GetEffectManager Instace { get { return instance; } }
    SpriteRenderer backGroundObj;
    Canvas getEffectCanvas;
    Image character;
    Text characterName;
    Vector3 tipeMarkObj;
    Image getImage;
    static GetEffectBase effectBase;
    AudioSource source;
    public enum BackGroundColor
    {
        Fire,
        Ice,
    }
    bool isUpdate = false;
    public GetEffectManager()
    {
        backGroundObj = GameObject.Find("BackGroundObj").GetComponent<SpriteRenderer>();
        getEffectCanvas = GameObject.Find("GetEffectCanvas").GetComponent<Canvas>();
        character = GameObject.Find("CharacterImage").GetComponent<Image>();
        characterName = GameObject.Find("CharacterName").GetComponent<Text>();
        source = getEffectCanvas.GetComponent<AudioSource>();
        getImage = GameObject.Find("GetImage").GetComponent<Image>();
        GameObject mark = GameObject.Find("Mark");
        tipeMarkObj = mark.transform.position;
        instance = this;
        getEffectCanvas.gameObject.SetActive(false);
    }
    public Vector3 TipeMrakPostion { get { return tipeMarkObj; } }
    public Text CharacterText { get { return characterName; } }
    public AudioSource Audio { get { return source; } }
    public Image GetImage { get { return getImage; } }
    public  GetEffectBase EffectInstance
    {
        get { return effectBase; }
        set { effectBase = value; }
    }
    public Image CharacterImage { get { return character; } }
    public void PlayEffect(int number)
    {
        switch (number)
        {
            case 146://ファイア-
                GetEffectBase fire = new GetFireEffect(number);
                effectBase = fire;
                isUpdate = true;
                break;
            case 144:
                GetEffectBase friiezer = new GetIceEffect(number);
                effectBase = friiezer;
                isUpdate = true;
                break;
        }
    }

    public void ChangeCanvas()
    {
        CanvasManager.Canvas.SetActive(false);
        getEffectCanvas.gameObject.SetActive(true);
        backGroundObj.gameObject.SetActive(true);
    }

    public void Reset()
    {
        CanvasManager.Canvas.SetActive(true);
        getEffectCanvas.gameObject.SetActive(false);
        backGroundObj.gameObject.SetActive(false);
    }

    public void BackGroundColorChange(BackGroundColor color)
    {
        Color changecolor = new Color();

        switch (color)
        {
            case BackGroundColor.Fire:
                changecolor.a = 1;
                changecolor.r = 0.5f;
                changecolor.g = 0;
                changecolor.b = 0.1f;
                backGroundObj.color = changecolor;
                break;
            case BackGroundColor.Ice:
                changecolor.a = 1;
                changecolor.r = 0.05f;
                changecolor.g = 0.1f;
                changecolor.b = 0.1f;
                backGroundObj.color = changecolor;
                break;
        }
    }

    public void EffectUpdate()
    {
        if (isUpdate)
        {
            effectBase.EffectUpdate();
        }
    }

    public void Finish()
    {
        isUpdate = false;
        Reset();
    }

}
