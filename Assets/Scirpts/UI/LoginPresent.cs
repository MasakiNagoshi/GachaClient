using UnityEngine;
using UnityEngine.UI;

public class LoginPresent
{
    static LoginPresent instance;
    Text messageText;
    Image itemImage;
    public LoginPresent()
    {
        GameObject messageObj = GameObject.Find("Message");
        GameObject itemObj = GameObject.Find("ItemImage");
        itemImage = itemObj.GetComponent<Image>();
        messageText = messageObj.GetComponent<Text>();
        string message = "";
        string present = PlayerPrefs.GetString("loginpresent");
        Debug.Log(present);
        string[] split = present.Split(':');
        ItemRate(ref message,split);
        message += "☓";
        ItemCount(ref message, split);
        message += "入手しました！";
        messageText.text = message;
    }

    void ItemRate(ref string message,string[] split)
    {
        switch (split[0])
        {
            case "1":
                message += "ノーマルチケット";
               itemImage.sprite =  SpriteManager.Instance.GetSprite(0);
                break;
            case "2":
                message += "スペシャルチケット";
                itemImage.sprite = SpriteManager.Instance.GetSprite(1);
                break;
        }
    }

    void ItemCount(ref string message, string[] split)
    {
        message += split[1];
    }

}
