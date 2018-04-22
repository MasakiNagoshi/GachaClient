
using UnityEngine;
using UnityEngine.UI;
public class EmmisionGachaMaster : MonoBehaviour
{
    [SerializeField]
    Button rateButton;
    void Start()
    {
        CanvasManager canvasManager = new CanvasManager();
        RateManager rateManager = new RateManager(rateButton);
        EmmisionGachaManager manager = new EmmisionGachaManager();
    }
}
