using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GachaManager
{
    public GachaManager(Image instance,GameObject parentObj)
    {
        Ini(instance,parentObj);
    }

    void Ini(Image instance, GameObject parentObj)
    {
        RateManager.rRate = instance;
        RateManager.parentObj = parentObj;
    }
}
