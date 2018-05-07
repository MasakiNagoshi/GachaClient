/////////////////////////////////
//制作者　名越大樹
//GachaRateクラスを生成するクラス
/////////////////////////////////

public class GachaRateInstance
{
    static GachaRateInstance instance;
    const string N_RATE = "n";
    const string R_RATE = "r";
    const string SR_RATE = "sr";
    const string SSR_RATE = "ssr";
    GachaRate gachaRate;

    public static GachaRateInstance Instance
    {
        get
        {
            if (instance == null)
            {
                GachaRateInstance gacha = new GachaRateInstance();
            }
            return instance;
        }
    }

    public GachaRateInstance()
    {
        instance = this;
    }

    public void GachaRate(string rate, string dictionary, bool duplication)
    {
        switch (rate)
        {
            case N_RATE:
                GachaRate nrate = new NRate();
                gachaRate = nrate;
                nrate.Instance(rate, EmmisionCharacterRateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication, dictionary);
                break;
            case R_RATE:
                GachaRate rrate = new RRate();
                gachaRate = rrate;
                rrate.Instance(rate, EmmisionCharacterRateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication, dictionary);
                break;
            case SR_RATE:
                GachaRate srrate = new SRRate();
                gachaRate = srrate;
                srrate.Instance(rate, EmmisionCharacterRateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication, dictionary);
                break;
            case SSR_RATE:
                GachaRate ssrrate = new SSRRate();
                gachaRate = ssrrate;
                ssrrate.Instance(rate, EmmisionCharacterRateManager.RateObj, EmmisionGachaManager.EmmisonCharacteresParent, duplication, dictionary);
                ssrrate.EffectAction();
                break;
        }
    }
}
