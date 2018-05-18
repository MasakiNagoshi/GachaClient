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

    public GameObject InstanceObj { get { return instanceObj; } }
    public int Count { get { return count; } }
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
    }

    public void MasterStone()
    {
        instanceObj = GameObject.Find("MasterStone");
    }

    void ChanegSprite()
    {
        var image = instanceObj.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("Image/Mark" + type);
    }

    void UpdateText()
    {
        countText = instanceObj.GetComponentInChildren<Text>();
        countText.text = count.ToString();
    }
}
