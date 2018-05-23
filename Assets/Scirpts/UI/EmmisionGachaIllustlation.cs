//////////////////////////////////////////////////////////////
//制作者　名越大樹
//排出されたキャラクターの画像を読み込みを行うクラス
//////////////////////////////////////////////////////////////

using UnityEngine;
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
    const string CHARACTER_ILLUST_FOLDER = "Image/CharacterIllust/";
    const string MONSTERBALL_ILLUST_FOLDER = "Image/MonsterBall/";
    const string N_IMAGE = "NRateImage";
    const string R_IMAGE = "RRateImage";
    const string SR_IMAGE = "SRRateImage";
    const string SSR_IMAGE = "SSRRateImage";

    public static EmmisionGachaIllustlation Instance { get { return instance; } }

    public EmmisionGachaIllustlation(string rate)
    {
        instance = this;
    }

    public Sprite ReadImage(string rate, string number)
    {
        switch (rate)
        {
            case N_RATE:
                rate = N_IMAGE;
                break;
            case R_RATE:
                rate = R_IMAGE;
                break;
            case SR_RATE:
                rate = SR_IMAGE;
                break;
            case SSR_RATE:
                rate = SSR_IMAGE;
                break;
        }
        if (int.Parse(number) >= 10 && int.Parse(number) < 100)
        {
            number = "0" + number;
        }
        else if (int.Parse(number) <= 10)
        {
            number = "00" + number;
        }
        return Resources.Load<Sprite>(CHARACTER_ILLUST_FOLDER + rate + "/" + number);
    }

    public Sprite GetMonsterBallRateImage(string rate)
    {
        switch (rate)
        {
            case N_RATE:
                return Resources.Load<Sprite>(MONSTERBALL_ILLUST_FOLDER + "N");
            case R_RATE:
                return Resources.Load<Sprite>(MONSTERBALL_ILLUST_FOLDER + "R");
            case SR_RATE:
                return Resources.Load<Sprite>(MONSTERBALL_ILLUST_FOLDER + "SR");
            case SSR_RATE:
                return Resources.Load<Sprite>(MONSTERBALL_ILLUST_FOLDER + "SSR");
        }
        return null;
    }

    public void Clear()
    {
        illustArray = null;
    }
}
