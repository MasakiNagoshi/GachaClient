using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RateManager
{
    public RateManager(Button rate)
    {
        rateObj = rate;
    }

    static Button rateObj;
    public static Button RateObj { get { return rateObj; } }
}
