///////////////////////////////////////////////////////////////////
//制作者　名越大樹
//石を購入時の確認のパラメータを管理するクラス
///////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using HTTP;
using Protocol;

public class ConfirmationStoneParamater
{
    string attachItemName;
    int number;
    Button addButton;
    Button minusButton;
    Button okButton;
    Button cancelButton;
    Text numbertText;
    string type;
    const string NUMBET_TEXT_OBJ = "NumberText";
    const string ATTACH_ITEM_TEXT_OBJ = "AttachItemText";
    const string ATTACH_ITEM_IMAGE_OBJ = "AttachImage";
    const string ADD_BUTTOB_OBJ = "Add";
    const string MINUS_BUTTON_OBJ = "Minus";
    const string OK_BUTTON_OBJ = "OkButton";
    const string CANSEL_BUTTON_OBJ = "CancelButton";
    const string CLICK_SE_FILE = "SE/Money/money-drop2";
    public string AttachItemName { get { return attachItemName; } }
    public int Number { get { return number; } }

    public ConfirmationStoneParamater(string setAttachItemName,Sprite setImage,string setType)
    {
        type = setType;
        number = 1;
        numbertText = GameObject.Find(NUMBET_TEXT_OBJ).GetComponent<Text>();
        var targetNameText = GameObject.Find(ATTACH_ITEM_TEXT_OBJ).GetComponent<Text>();
        var targetImage = GameObject.Find(ATTACH_ITEM_IMAGE_OBJ).GetComponent<Image>();
        addButton = GameObject.Find(ADD_BUTTOB_OBJ).GetComponent<Button>();
        minusButton = GameObject.Find(MINUS_BUTTON_OBJ).GetComponent<Button>();
        targetNameText.text = setAttachItemName;
        targetImage.sprite = setImage;
        numbertText.text = number.ToString();
        attachItemName = setAttachItemName;
        ButtonesSetting();
    }

    public void BuyStoneItem()
    {
        RequestBuyStoneItem param = new RequestBuyStoneItem();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        param.type = type;
        param.count = number.ToString();
        ApiClient.Instance.RequestBuyStoneItem(param);
        ConfirmationStoneManager.Instance.SetActive(false);
        number = 1;
    }
    public void RemoveListeners()
    {
        addButton.onClick.RemoveAllListeners();
        minusButton.onClick.RemoveAllListeners();
        okButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
    }

    void ButtonesSetting()
    {
        addButton.onClick.AddListener(() =>
        {
            AddValue();
        });
        minusButton.onClick.AddListener(()
            =>
        {
            MinusValue();
        });
        okButton = GameObject.Find(OK_BUTTON_OBJ).GetComponent<Button>();
        okButton.onClick.AddListener(() =>
        {
            Click click = new Click(Resources.Load<AudioClip>(CLICK_SE_FILE));
            click.PlaySe();
            BuyStoneItem();
            RemoveListeners();
        });
        cancelButton = GameObject.Find(CANSEL_BUTTON_OBJ).GetComponent<Button>();
        cancelButton.onClick.AddListener(() =>
        {
            ConfirmationStoneManager.Instance.SetActive(false);
        });
    }

    void UpdateCount()
    {
        RequestGetAllStones param = new RequestGetAllStones();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        ApiClient.Instance.RequestGetAllStones(param);
    }

    public void AddValue()
    {
        if (StoneManager.Instance.MasterStone.Count <= number)
        {
            return;
        }
        number++;
        numbertText.text = number.ToString();
    }

    public void MinusValue()
    {
        if (number <= 0)
        {
            return;
        }
        number--;
        numbertText.text = number.ToString();
    }
}