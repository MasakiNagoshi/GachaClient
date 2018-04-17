using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GachaRate : MonoBehaviour
{
    public GachaRate() { }
	public GachaRate(string rate,string dictionary,bool duplication)
    {
        switch (rate)
        {
			case "n":
			NRate nrate = new NRate ();
			nrate.Instance (RateManager.RateImage,EmmisionGachaManager.EmmisonCharacteresParent,duplication);
                break;
            case "r":
                RRate rrate = new RRate();
                Debug.Log("レアです");
			rrate.Instance(RateManager.RateImage, EmmisionGachaManager.EmmisonCharacteresParent, duplication);
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
