////////////////////////////////////////////////////////////
//制作者　名越大樹
//初めて取得した排出キャラクターの演出全体を管理するクラス
////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class GetEffectManager
{
    static GetEffectManager instance;
    SpriteRenderer backGroundObj;//演習用の背景画像
    Canvas getEffectCanvas;//演出用のCanvas
    Image character;//取得したキャラクターの画像
    Text characterName;//キャラクターの名まえを表示するテキスト
    Vector3 tipeMarkObj;//取得したキャラクターのタイプの演出場所
    Image getImage;
    static GetEffectBase effectBase;
    AudioSource source;
    bool isUpdate = false;
    public enum BackGroundColor
    {
        Fire,
        Ice,
        Thunder,
        Esper,
    }
    const string BACK_GROUND_NAME = "BackGroundObj";
    const string EFFECT_CANVAS_NAME = "GetEffectCanvas";
    const string CHARACTER_IMAGE = "CharacterImage";
    const string CHARACTER_TEXT_NAME = "CharacterText";
    const string GET_IMAGE_NAME = "GetImage";
    const string MARK_NAME = "Mark";

    public Vector3 TipeMrakPostion { get { return tipeMarkObj; } }
    public Text CharacterText { get { return characterName; } }
    public AudioSource Audio { get { return source; } }
    public Image GetImage { get { return getImage; } }
    public GetEffectBase EffectInstance { get { return effectBase; } set { effectBase = value; } }
    public Image CharacterImage { get { return character; } }
    public static GetEffectManager Instace { get { return instance; } }

    public GetEffectManager()
    {
        Ini();
    }

    public void PlayEffect(int number)
    {
        GetCharacterType.Type type = GetCharacterType.GetType(number);
        switch (type)
        {
            case GetCharacterType.Type.Fire:
                GetEffectBase fire = new GetFireEffect(number);
                effectBase = fire;
                isUpdate = true;
                break;
            case GetCharacterType.Type.Ice:
                GetEffectBase friiezer = new GetIceEffect(number);
                effectBase = friiezer;
                isUpdate = true;
                break;
            case GetCharacterType.Type.Thunder:
                GetEffectBase thunder = new GetThunderEffect(number);
                effectBase = thunder;
                isUpdate = true;
                break;
            case GetCharacterType.Type.Esper:
                GetEffectBase esper = new GetEsperEffect(number);
                effectBase = esper;
                isUpdate = true;
                break;
            case GetCharacterType.Type.Aqua:
                GetEffectBase aqua = new GetWaterEffect(number);
                effectBase = aqua;
                isUpdate = true;
                break;
            case GetCharacterType.Type.Leaf:
                GetEffectBase leaf = new GetLeafEffect(number);
                effectBase = leaf;
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
            case BackGroundColor.Thunder:
                backGroundObj.color = Color.black;
                break;
            case BackGroundColor.Esper:
                backGroundObj.color = Color.black;
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

    void Ini()
    {
        backGroundObj = GameObject.Find(BACK_GROUND_NAME).GetComponent<SpriteRenderer>();
        getEffectCanvas = GameObject.Find(EFFECT_CANVAS_NAME).GetComponent<Canvas>();
        character = GameObject.Find(CHARACTER_IMAGE).GetComponent<Image>();
        characterName = GameObject.Find(CHARACTER_TEXT_NAME).GetComponent<Text>();
        source = getEffectCanvas.GetComponent<AudioSource>();
        getImage = GameObject.Find(GET_IMAGE_NAME).GetComponent<Image>();
        GameObject mark = GameObject.Find(MARK_NAME);
        tipeMarkObj = mark.transform.position;
        instance = this;
        getEffectCanvas.gameObject.SetActive(false);
    }
}
