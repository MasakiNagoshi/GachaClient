using UnityEngine;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
    Text  rateText;
    Text messageText;

    void Start()
    {
        GameObject text = GameObject.Find("message");
        GameObject rate = GameObject.Find("rate");
        rateText = rate.GetComponent<Text>();
        messageText = text.GetComponent<Text>();
    }

    public void OkButton()
    {
        SceneManagers.SceneLoad( SceneManagers.SceneName.EmmisionGacha);
    }

    public void CancelButton()
    {
        ConfirmationManager.Instance.SetActive(false);
    }

    public void UpdateMessage()
    {
        string message = "";
        int ticket = AttachRate.AttachGachaRate.GetCount();
        if (ticket >= 10)
        {
            AttachRate.AttachGachaRate.SetUseCount(10);
        }
        else
        {
            AttachRate.AttachGachaRate.SetUseCount(ticket);
        }
        if (AttachRate.AttachGachaRate.GetType() == typeof(SpecalGacha))
        {
            rateText.text = "スペシャルチケット";
        }
        else
        {
            rateText.text = "ノーマルチケット";
        }
        message = AttachRate.AttachGachaRate.GetUseCount().ToString() + "枚使用しますか？";
        messageText.text = message;
    }

    void UpdateUseMessage()
    {
        messageText.text = AttachRate.AttachGachaRate.GetUseCount().ToString() + "枚使用しますか？";
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

    void SetAttach()
    {

    }
}
