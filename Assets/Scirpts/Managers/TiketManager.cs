using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiketManager
{
    public static TicketBase ticket;
    public TiketManager()
    {
        NormalTicket noraml = new NormalTicket();
        SpecalTicket spcal = new SpecalTicket();
    }
}
