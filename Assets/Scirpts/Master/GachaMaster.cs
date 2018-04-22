using UnityEngine;
using UnityEngine.UI;
using HTTP;
using Protocol;

public class GachaMaster : MonoBehaviour
{
    [SerializeField]
    Button rateButton;

	void Start ()
    {
        GachaManager manager = new GachaManager(rateButton);
        TiketManager ticket = new TiketManager();
        ConfirmationManager confirmation = new ConfirmationManager();
        IniRequest();
	}

    void IniRequest()
    {
        GetTicket();
    }

    void GetTicket()
    {
        RequestGetGachaTicket param = new RequestGetGachaTicket();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        ApiClient.Instance.RequestGetGachaTiket(param);
    }
}
