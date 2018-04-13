using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecalTicket
{
    static Text text;

    public SpecalTicket()
    {
        GameObject obj = GameObject.Find("Specal");
        text = obj.GetComponent<Text>();
    }
    public static Text Ticket{ get { return text; }  set { text = value; } }
}
