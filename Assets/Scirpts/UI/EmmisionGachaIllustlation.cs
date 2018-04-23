
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmmisionGachaIllustlation
{
    Sprite[] illustArray;
    static EmmisionGachaIllustlation instance;
    List<Sprite> illustList;
    const string N_RATE = "n";
    const string R_RATE = "r";
    const string SR_RATE = "sr";
    const string SSR_RATE = "ssr";
    public EmmisionGachaIllustlation(string rate)
    {
        instance = this;

        switch (rate)
        {
            case "normal":
             //   illustArray = Resources.LoadAll<Sprite>("Image/CharacterIllust/NRateImage");
             //   Debug.Log(illustArray[0]);
                break;
            case "specal":
            //    Sprite[] r = Resources.LoadAll<Sprite>("Image/CharacterIllust/RRateImage");
            //    Sprite[] sr = Resources.LoadAll<Sprite>("Image/CharacterIllust/SRRateImage");
            //    Sprite[] ssr = Resources.LoadAll<Sprite>("Image/CharacterIllust/SSRRateImage");
             //   illustList = new List<Sprite>(r.Length + sr.Length + ssr.Length);
                break;
        }
    }

    public Sprite ReadImage(string rate, string number)
    {
        switch (rate)
        {
            case "n":
                rate = "NRateImage";
                break;
            case "r":
                rate = "RRateImage";
                break;
            case "sr":
                rate = "SRRateImage";
                break;
            case "ssr":
                rate = "SSRRateImage";
                break;
        }
        if(int.Parse(number) >= 10 && int.Parse(number) < 100)
        {
            number = "0" + number;
        }
        else if(int.Parse(number) <= 10)
        {
            number = "00" + number;
        }
        return Resources.Load<Sprite>("Image/CharacterIllust/" + rate + "/" + number);

    }

    public static EmmisionGachaIllustlation Instance { get { return instance; } }


    public Sprite GetMonsterBallRateImage(string rate)
    {
        switch (rate)
        {
            case N_RATE:
                Debug.Log(Resources.Load<Sprite>("Image/MonsterBall/N"));
                return Resources.Load<Sprite>("Image/MonsterBall/N");
            case R_RATE:
                return Resources.Load<Sprite>("Image/MonsterBall/R");
            case SR_RATE:
                return Resources.Load<Sprite>("Image/MonsterBall/SR");
            case SSR_RATE:
                return Resources.Load<Sprite>("Image/MonsterBall/SSR");
        }
        return null;
    }

    public void Clear()
    {
        illustArray = null;
    }
}
