using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RateManager
{
    public RateManager(Image rate)
    {
        rateObj = rate;
    }

    static Image rateObj;
    public static Image RateImage { get { return rateObj; } }
}
