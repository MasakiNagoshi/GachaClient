using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecalTicket
{
    Text text;
    static SpecalTicket instance;
    int count = 0;
    int useCount = 0;
    public SpecalTicket()
    {
        instance = this;
        GameObject obj = GameObject.Find("Specal");
        text = obj.GetComponent<Text>();
    }

    public void AddUseCount(bool value)
    {
        int addusecount = 0;
        if (value)
        {
            addusecount = 1;
        }
        else
        {
            addusecount = -1;
        }
        bool result = ErrorCheck.Instance.CheckAddUseCount(useCount + addusecount, count);
        if (result)
        {
            useCount += addusecount;
        }
    }

    public int UseCount { get { return useCount; } set { useCount = value; } }
    public static SpecalTicket Instance { get { return instance; } }
    public Text Ticket{ get { return text; }  set { text = value; } }
    public int Count { get { return count; } set { count = value; } }
}
