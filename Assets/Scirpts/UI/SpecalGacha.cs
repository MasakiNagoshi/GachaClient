/////////////////////////////////////
//制作者　名越大樹
//スペシャルガチャを行うクラス
//////////////////////////////////////

using UnityEngine;
using HTTP;
using Protocol;
using UnityEngine.UI;

public class SpecalGacha : GachaBase
{
    const string GACHA_RATE = "specal";

    public override int GetMaxUseCount()
    {
      return  SpecalTicket.Instance.GetMaxUseCount();
    }

    public override string GetRate()
    {
        return SpecalTicket.Instance.GetRate();
    }

    public override void AddUseCount(bool value)
    {
        SpecalTicket.Instance.AddUseCount(value);
    }

    public override int GetUseCount()
    {
        return SpecalTicket.Instance.UseCount;
    }

    public override int GetCount()
    {
        return SpecalTicket.Instance.Count;
    }

    public override Text GetTicket()
    {
        return SpecalTicket.Instance.Ticket;
    }

    public override void Confirmation()
    {
        AttachRate.AttachGachaRate = this;
        ConfirmationManager.Instance.SetActive(true);
    }

    public override void SetUseCount(int usecount)
    {
        SpecalTicket.Instance.UseCount = usecount;
    }

    public override string GetGachaRate()
    {
        return GACHA_RATE;
    }

    public override void Gacha()
    {
        RequestGacha param = new RequestGacha();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        param.status = GACHA_RATE;
        param.limit = SpecalTicket.Instance.Count.ToString();
        param.used_specal_ticket = SpecalTicket.Instance.UseCount.ToString();
        Debug.Log(SpecalTicket.Instance.Count.ToString());
        param.used_noraml_ticket = 0.ToString();
        ApiClient.Instance.RequesrGacha(param);
    }
}
