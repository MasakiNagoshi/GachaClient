//////////////////////////////////////////////////
//制作者　名越大樹
//石のアイテムのパラメーターを管理するクラス
//////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class StoneItemParamater
{
    int count;
    string type;
    GameObject instanceObj;
    Text countText;
    Text typeText;
    Image image;
    const string BUTTON_OBJ = "Button";
    const string TYPE_TEXT_OBJ = "Type";
    const string COUNT_TEXT_OBJ = "Count";
    const string IMAGE_FOLDER = "Image/Type/";
    const string MASTER_IMAGE_OBJ = "MasterImage";
    const string MASTER_COUNT_TEXT_OBJ = "MasterCount";
    const int FONT_SIZE = 24;
    public GameObject InstanceObj { get { return instanceObj; } }
    public int Count { get { return count; } set { count = value; countText.text = count.ToString(); } }
    public string Type { get { return type; } }

    public StoneItemParamater(int setCount, string setType)
    {
        count = setCount;
        type = setType;
    }

    public void Instance(GameObject setObj)
    {
        instanceObj = setObj;
        instanceObj.name = type;
        UpdateText();
        ChanegSprite();
        SetParent();
    }

    public void MasterStone()
    {
        MasterSetting();
    }

    void ChanegSprite()
    {
        image = instanceObj.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(IMAGE_FOLDER + type);
    }

    void UpdateText()
    {
        foreach (Transform child in instanceObj.transform)
        {
            switch (child.gameObject.name)
            {
                case BUTTON_OBJ:
                    ButtonSetting(child.gameObject);
                    break;
                case TYPE_TEXT_OBJ:
                    TypeTextSetting(child.gameObject);
                    break;
                case COUNT_TEXT_OBJ:
                    CountTextSetting(child.gameObject);
                    break;
            }
        }
    }

    void ButtonSetting(GameObject target)
    {
        var button = target.GetComponent<Button>();
        button.onClick.AddListener(() =>
            {
                ConfirmationStoneManager.Instance.SetActive(true, typeText.text, count, image.sprite, type);
            });
    }

    void TypeTextSetting(GameObject target)
    {
        typeText = target.gameObject.GetComponent<Text>();
        typeText.text = UpdateStoneMessage.UpdateMasterMessage(type);
    }

    void CountTextSetting(GameObject target)
    {
        countText = target.gameObject.GetComponent<Text>();
        countText.fontSize = FONT_SIZE;
        countText.text = count.ToString();
    }

    void SetParent()
    {
        instanceObj.transform.parent = ScrollViewManager.Instance.Content.transform;
    }

    void MasterSetting()
    {
        var masterImage = GameObject.Find(MASTER_IMAGE_OBJ).GetComponent<Image>();
        countText = GameObject.Find(MASTER_COUNT_TEXT_OBJ).GetComponent<Text>();
        masterImage.sprite = Resources.Load<Sprite>(IMAGE_FOLDER + type);
        countText.text = count.ToString();
    }
}
