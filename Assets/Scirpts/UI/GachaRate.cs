using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class GachaRate : MonoBehaviour
{
    public GachaRate() { }
	public GachaRate(string rate,string dictionary,bool duplication)
    {
        switch (rate)
        {
			case "n":
			GachaRate nrate = new NRate();
			nrate.Instance (RateManager.RateImage,EmmisionGachaManager.EmmisonCharacteresParent,duplication,dictionary);
                break;
            case "r":
                RRate rrate = new RRate();
                Debug.Log("レアです");
			rrate.Instance(RateManager.RateImage, EmmisionGachaManager.EmmisonCharacteresParent, duplication,dictionary);
                break;
            case "sr":
                break;
            case "ssr":
                break;
        }
    }
    public virtual void EffectAction() { }
    public virtual void Instance(Image instanceobj, GameObject parent, bool duplication,string dictionary) { }
}
