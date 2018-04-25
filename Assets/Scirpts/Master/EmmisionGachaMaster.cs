/////////////////////////////////////
//製作者　名越大樹
//EmmisionGachaシーンでの全体を管理するクラス
/////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class EmmisionGachaMaster : MonoBehaviour
{
    [SerializeField]
    Button rateButton;
    EmmisionUpdateManager updateManager;
    void Start()
    {
        CanvasManager canvasManager = new CanvasManager();
        RateManager rateManager = new RateManager(rateButton);
        EmmisionGachaManager manager = new EmmisionGachaManager();
        EmmisionUpdateManager update = new EmmisionUpdateManager();
        updateManager = update;
    }

    void Update()
    {
        updateManager.Update();
    }
}
