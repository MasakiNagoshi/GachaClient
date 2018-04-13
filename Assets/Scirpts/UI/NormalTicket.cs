using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalTicket : TicketBase
{
    private int count;
    static Text text;

    public NormalTicket()
    {
        GameObject obj = GameObject.Find("Normal");
        text = obj.GetComponent<Text>();
    }
    public static Text Ticket { get { return text; } set { text = value; } }
}
