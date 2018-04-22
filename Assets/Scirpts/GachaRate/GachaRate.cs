///////////////////////////////////////////
//制作者　名越大樹
//排出キャラクターのレートの基底クラス
///////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public  class GachaRate : MonoBehaviour
{
    const string N_RATE = "n";
    const string R_RATE = "r";
    const string SR_RATE = "sr";
    const string SSR_RATE = "ssr";

    public GachaRate() { }

	public GachaRate(string rate,string dictionary,bool duplication)
    {
        switch (rate)
        {
			case N_RATE:
			GachaRate nrate = new NRate();
			nrate.Instance (rate,RateManager.RateObj,EmmisionGachaManager.EmmisonCharacteresParent,duplication,dictionary);
                break;
            case R_RATE:
                GachaRate rrate = new RRate();
			rrate.Instance(rate,RateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication,dictionary);
                break;
            case SR_RATE:
                GachaRate srrate = new SRRate();
                srrate.Instance(rate,RateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication, dictionary);
                break;
            case SSR_RATE:
                GachaRate ssrrate = new SSRRate();
               ssrrate.Instance(rate,RateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication, dictionary);
                break;
        }
    }

    public virtual void EffectAction() { }

    public virtual Button Instance(string rate, Button instanceobj, GameObject parent, bool duplication,string dictionary)
    {
        var obj = Instantiate(instanceobj);
        obj.transform.parent = parent.transform;
        obj.onClick.AddListener(() =>
        {
            Debug.Log(dictionary);
           ChangeColor(rate,duplication,int.Parse(dictionary),obj);
        });
        obj.GetComponent<Image>().sprite = EmmisionGachaIllustlation.Instance.GetMonsterBallRateImage(rate);
        SkipButton.Instance.AddSkip(rate,duplication,int.Parse(dictionary),obj,this);

        return obj;
    }

    public virtual void ChangeColor(string rate,bool duplication,int number,Button rateobj)
    {
        if (rateobj != null)
        {
            Sprite image = EmmisionGachaIllustlation.Instance.ReadImage(rate, number.ToString());
            rateobj.GetComponent<Image>().sprite = image;
            if (!duplication)
            {
                Duplication dup = new Duplication(rateobj.gameObject);
            }
            rateobj.enabled = false;
        }
    }
}
