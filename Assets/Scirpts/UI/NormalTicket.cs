////////////////////////////////////////
//制作者　名越大樹
//ノーマルチケットに関するクラス
////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class NormalTicket : TicketBase
{
    int count = 0;
    Text text;
    static NormalTicket noraml;
    int useCount = 0;
    const string RATE = "ノーマルチケット";
    const int MAX_USE_COUNT = 10;

    public string GetRate()
    {
        return RATE;
    }

    public int GetMaxUseCount()
    {
        return MAX_USE_COUNT;
    }

    public NormalTicket()
    {
        noraml = this;
        GameObject obj = GameObject.Find(ObjectName.NORMAL_TICKET);
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
        bool result = ErrorCheck.Instance.CheckAddUseCount(useCount + addusecount, count);
        if (result)
        {
            useCount += addusecount;
        }
    }

    public int UseCount
    {
        get { return useCount; }
        set { useCount = value; }
    }

    public int Count { get { return count; } set { count = value; } }
    public static NormalTicket Instance { get { return noraml; } }
}
