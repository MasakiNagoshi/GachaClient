
using UnityEngine;
using HTTP;
using Protocol;

public class SpecalGacha : GachaBase
{
    string status = "specal";
    [SerializeField]
    int limit;
    public override void Gacha()
    {
        RequestGacha param = new RequestGacha();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        param.status = status;
        param.limit = limit.ToString();
        ApiClient.Instance.RequesrGacha(param);
    }
}
