using UnityEngine;
using HTTP;
using Protocol;
using UnityEngine.UI;
using System;

public class NormalGacha : GachaBase
{
    int limit = 10;
    const string GACHA_RATE = "normal";

    public override void AddUseCount(bool value)
    {
        NormalTicket.Instance.AddUseCount(value);
    }
    public override int GetUseCount()
    {
        return NormalTicket.Instance.UseCount;
    }

    public override Text GetTicket()
    {
        return NormalTicket.Instance.Ticket;
    }

    public override int GetCount()
    {
        return NormalTicket.Instance.Count;
    }

    public override void SetUseCount(int usecount)
    {
        NormalTicket.Instance.UseCount = usecount;
    }

    public override void Confirmation()
    {
        if (AttachRate.AttachGachaRate != this)
        {
            Click.Instance.PlaySe();
        }
        AttachRate.AttachGachaRate = this;
        ConfirmationManager.Instance.SetActive(true);
    }

    public override int GetMaxUseCount()
    {
        return NormalTicket.Instance.GetMaxUseCount();
    }

    public override string GetRate()
    {
        return NormalTicket.Instance.GetRate();
    }

    public override void Gacha()
    {
        RequestGacha param = new RequestGacha();
        param.limit = NormalTicket.Instance.Count.ToString();
        param.status = GACHA_RATE;
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        param.used_noraml_ticket = NormalTicket.Instance.UseCount.ToString();
        param.used_specal_ticket = 0.ToString();
        ApiClient.Instance.RequesrGacha(param);
    }

    public override string GetGachaRate()
    {
        return GACHA_RATE;
    }
}
