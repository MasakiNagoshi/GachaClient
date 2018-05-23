////////////////////////////////////////////
//制作者　名越大樹
//石を購入するときの確認を管理するクラス
////////////////////////////////////////////

using UnityEngine;

public class ConfirmationStoneManager
{
    GameObject confirmation;
    static ConfirmationStoneManager manager;

    public static ConfirmationStoneManager Instance { get { return manager; } }

    public ConfirmationStoneManager()
    {
        manager = this;
        confirmation = GameObject.Find(ObjectName.CONFIRAMATION);
        confirmation.gameObject.SetActive(false);
    }

    public void SetActive(bool set)
    {
        confirmation.gameObject.SetActive(set);
    }

    public void SetActive(bool set,string attachName,int number,Sprite sprite,string type)
    {
        confirmation.gameObject.SetActive(set);
        ConfirmationStoneParamater param = new ConfirmationStoneParamater(attachName, sprite,type);
    }
}
