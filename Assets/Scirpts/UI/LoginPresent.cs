///////////////////////////////////////
//制作者　名越大樹
//ログインボーナスの設定に関するクラス
///////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class LoginPresent
{
    Text messageText;
    Image itemImage;
    const string NORMAL_TICKET = "ノーマルチケット";
    const string SPECAL_TICKET = "スペシャルチケット";
    const string LOGIN_PRESENT = "loginpresent";
    const string SE_OBJ = "SeObj";
    const string SE_FILE = "SE/Login/loginBornusSe01";
    const char SPLIT_FONT = ':';

    public LoginPresent()
    {
        PresetSetting();
        PlaySe();
    }

    void PresetSetting()
    {
        GameObject messageObj = GameObject.Find(ObjectName.MESSAGE_TEXT);
        GameObject itemObj = GameObject.Find(ObjectName.ITEM_IMAGE);
        itemImage = itemObj.GetComponent<Image>();
        messageText = messageObj.GetComponent<Text>();
        string message = "";
        string present = PlayerPrefs.GetString(LOGIN_PRESENT);
        string[] split = present.Split(SPLIT_FONT);
        ItemRate(ref message, split);
        message += "☓";
        ItemCount(ref message, split);
        message += "入手しました！";
        messageText.text = message;
        ItemRate(ref message, split);
    }

    void ItemRate(ref string message, string[] split)
    {
        switch (split[0])
        {
            case NetWorkKey.NORMAL_TICKET_ID:
                message += NORMAL_TICKET;
                itemImage.sprite = SpriteManager.Instance.GetSprite(0);
                break;
            case NetWorkKey.SPECAL_TICKET_ID:
                message += SPECAL_TICKET;
                itemImage.sprite = SpriteManager.Instance.GetSprite(1);
                break;
        }
    }

    void PlaySe()
    {
        GameObject seObj = GameObject.Find(SE_OBJ);
        AudioSource audio = seObj.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>(SE_FILE);
        audio.Play();
    }

    void ItemCount(ref string message, string[] split)
    {
        message += split[1];
    }

}
