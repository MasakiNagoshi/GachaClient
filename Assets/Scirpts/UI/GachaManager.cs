
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
        GameObject parent = GameObject.Find("Canvas");
        CanvasManager.Canvas = parent;
        RateManager manager = new RateManager(instance);
    }
}
