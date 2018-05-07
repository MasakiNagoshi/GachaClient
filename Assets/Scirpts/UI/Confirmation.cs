/////////////////////////////////////
//製作者　名越大樹
//ガチャチケットを使用するときのクラス
/////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
    Text rateText;
    Text messageText;
    Button okButton;
    const string OK_BUTTON_OBJ = "OkButton";

    void Start()
    {
        GameObject text = GameObject.Find(ObjectName.MESSAGE_TEXT);
        GameObject rate = GameObject.Find(ObjectName.RATE_TEXT);
        okButton = GameObject.Find(OK_BUTTON_OBJ).GetComponent<Button>();
        rateText = rate.GetComponent<Text>();
        messageText = text.GetComponent<Text>();
    }

    public void OkButton()
    {
        bool result = ErrorCheck.Instance.CheckUseCount(AttachRate.AttachGachaRate.GetUseCount());
        if (result)
        {
            SceneManagers.SceneLoad(SceneManagers.SceneName.EmmisionGacha);
        }
    }

    public void CancelButton()
    {
        ConfirmationManager.Instance.SetActive(false);
    }

    public void UpdateMessage()
    {
        int ticket = AttachRate.AttachGachaRate.GetCount();
        if (ticket >= AttachRate.AttachGachaRate.GetMaxUseCount())
        {
            AttachRate.AttachGachaRate.SetUseCount(AttachRate.AttachGachaRate.GetMaxUseCount());
        }
        else
        {
            AttachRate.AttachGachaRate.SetUseCount(ticket);
        }
        OkButtonColorChange(ticket);
        UpdateUseMessage();
    }

    void OkButtonColorChange(int ticket)
    {
        if (ticket == 0)
        {
            okButton.enabled = false;
            okButton.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            okButton.enabled = true;
            okButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void AddCount()
    {
        AddUseCount(true);
    }

    public void MinusCount()
    {
        AddUseCount(false);
    }

    void AddUseCount(bool value)
    {
        AttachRate.AttachGachaRate.AddUseCount(value);
        UpdateUseMessage();
    }

    void UpdateUseMessage()
    {
        rateText.text = AttachRate.AttachGachaRate.GetRate();
        messageText.text = AttachRate.AttachGachaRate.GetUseCount().ToString() + Message.INQUIRE_USE_COUNT;
    }
}
