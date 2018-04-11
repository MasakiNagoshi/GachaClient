using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GachaRate : MonoBehaviour
{
    public GachaRate() { }
    public GachaRate(string rate)
    {
        switch (rate)
        {
            case "n":
                break;
            case "r":
                RRate rrate = new RRate();
                rrate.Instance(RateManager.rRate, RateManager.parentObj);
                break;
            case "sr":
                break;
            case "ssr":
                break;
        }
    }
    public virtual void EffectAction() { }
    public virtual void Instance() { }
}
