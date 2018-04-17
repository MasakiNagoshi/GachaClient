﻿using UnityEngine;
using HTTP;
using Protocol;
using UnityEngine.UI;
using System;

public class NormalGacha : GachaBase
{
    int limit = 10;
    string rate = "normal";

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
        AttachRate.AttachGachaRate = this;
        ConfirmationManager.Instance.SetActive(true);
    }

    public override void Gacha()
    {
        RequestGacha param = new RequestGacha();
        param.limit = NormalTicket.Instance.Count.ToString();
        param.status = rate;
        param.user_id = PlayerPrefs.GetString("id");
        param.used_noraml_ticket = limit.ToString();
        param.used_specal_ticket = 0.ToString();
        ApiClient.Instance.RequesrGacha(param);
    }
}
