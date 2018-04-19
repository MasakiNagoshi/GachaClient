
using UnityEngine;
using UnityEngine.UI;

public class EmmisionGachaIllustlation
{
    Sprite[] illustArray;
    static EmmisionGachaIllustlation instance;
    public EmmisionGachaIllustlation(string rate)
    {
        instance = this;

        switch (rate)
        {
            case "normal":
                illustArray = Resources.LoadAll<Sprite>("Image/CharacterIllust/NRateImage");
                Debug.Log(illustArray[0]);
                break;
            case "specal":
                break;
        }
    }

    public static EmmisionGachaIllustlation Instance { get { return instance; } }

    public Sprite GetIllust(int number)
    {
        return illustArray[number - 1];
    }

    public void Clear()
    {
        illustArray = null;
    }
}
