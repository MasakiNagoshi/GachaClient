///////////////////////////////////////////////
//制作者　名越大樹
//スペシャルチケットに関するクラス
///////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class SpecalTicket
{
    Text text;
    static SpecalTicket instance;
    int count = 0;
    int useCount = 0;
    const string RATE = "スペシャルチケット";
    const int MAX_USE_COUNT = 10;

    public int UseCount { get { return useCount; } set { useCount = value; } }
    public static SpecalTicket Instance { get { return instance; } }
    public Text Ticket { get { return text; } set { text = value; } }
    public int Count { get { return count; } set { count = value; } }

    public string GetRate()
    {
        return RATE;
    }

    public SpecalTicket()
    {
        instance = this;
        GameObject obj = GameObject.Find(ObjectName.SPECAL_TICKET);
        text = obj.GetComponent<Text>();
    }

    public int GetMaxUseCount()
    {
        return MAX_USE_COUNT;
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
}
