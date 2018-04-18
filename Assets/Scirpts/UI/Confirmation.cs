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

    void Start()
    {
        GameObject text = GameObject.Find(ObjectName.MESSAGE_TEXT);
        GameObject rate = GameObject.Find(ObjectName.RATE_TEXT);
        Debug.Log(rate);
        rateText = rate.GetComponent<Text>();
        messageText = text.GetComponent<Text>();
    }

    public void OkButton()
    {
        SceneManagers.SceneLoad(SceneManagers.SceneName.EmmisionGacha);
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
        UpdateUseMessage();
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
