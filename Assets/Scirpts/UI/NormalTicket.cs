using UnityEngine;
using UnityEngine.UI;

public class NormalTicket : TicketBase
{
    int count = 0;
    Text text;
    static NormalTicket noraml;
    int useCount = 0;
    public NormalTicket()
    {
        noraml = this;
        GameObject obj = GameObject.Find("Normal");
        text = obj.GetComponent<Text>();
    }
    public Text Ticket
    {
        get { return text; }
        set
        {
            text = value;
            count = int.Parse(text.text);
        }
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
        bool result = ErrorCheck.Instance.CheckAddUseCount(useCount + addusecount,count);
        if(result)
        {
            useCount += addusecount;
        }
        Debug.Log(useCount);
    }
    public int UseCount
    {
        get { return useCount; }
        set { useCount = value; }
    }
    public int Count { get { return count; } set { count = value; } }
    public static NormalTicket Instance { get { return noraml; } }
}
