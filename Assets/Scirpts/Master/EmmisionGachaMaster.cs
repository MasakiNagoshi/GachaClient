
using UnityEngine;
using UnityEngine.UI;
public class EmmisionGachaMaster : MonoBehaviour
{
    [SerializeField]
    Image rateImage;
    void Start()
    {
        CanvasManager canvasManager = new CanvasManager();
        RateManager rateManager = new RateManager(rateImage);
        EmmisionGachaManager manager = new EmmisionGachaManager();
    }
}
