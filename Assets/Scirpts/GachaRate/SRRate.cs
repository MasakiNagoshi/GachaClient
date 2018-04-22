using UnityEngine;
using UnityEngine.UI;

public class SRRate : GachaRate
{
    int number;
    Button character;

    public override Button Instance(string rate,Button instanceobj, GameObject parent, bool duplication, string dictionary)
    {
        number = int.Parse(dictionary);
        character = base.Instance(rate,instanceobj, parent, duplication, dictionary);
        return null;
    }

    public override void ChangeColor(string rate, bool duplication, int number, Button rateobj)
    {
        base.ChangeColor(rate, duplication, number, rateobj);
    }
}
