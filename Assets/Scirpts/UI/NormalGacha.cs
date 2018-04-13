using UnityEngine;
using HTTP;
using Protocol;

public class NormalGacha : GachaBase
{

    int limit = 10;
    string rate = "normal";
    public override void Gacha()
    {
        RequestGacha param = new RequestGacha();
        param.limit = "10";
        param.status = rate;
        param.user_id = PlayerPrefs.GetString("id");
		param.used_noraml_ticket = limit.ToString();
		param.used_specal_ticket = 0.ToString ();
        ApiClient.Instance.RequesrGacha(param);
    }
}
