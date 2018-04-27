//////////////////////////////////////////
//制作者　名越大樹
//ガチャ出の確認画面全体を管理するクラス
//////////////////////////////////////////

using UnityEngine;

public class ConfirmationManager
{
    Confirmation confirmation;
    static ConfirmationManager manager;
    public static ConfirmationManager Instance{ get{ return manager; }}

    public ConfirmationManager()
    {
        manager = this;
        GameObject confrim = GameObject.Find(ObjectName.CONFIRAMATION);
        confirmation = confrim.GetComponent<Confirmation>();
        confirmation.gameObject.SetActive(false);
    }

    public void SetActive(bool set)
    {
        confirmation.UpdateMessage();
        confirmation.gameObject.SetActive(set);
    }
}
