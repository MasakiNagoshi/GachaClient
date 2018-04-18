
using UnityEngine;
using UnityEngine.UI;
public class GachaManager
{
    public GachaManager(Image instance)
    {
        Ini(instance);
    }

    void Ini(Image instance)
    {
        GameObject parent = GameObject.Find(ObjectName.CANVAS);
        CanvasManager.Canvas = parent;
        RateManager manager = new RateManager(instance);
    }
}
