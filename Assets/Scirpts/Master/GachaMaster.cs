using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GachaMaster : MonoBehaviour
{
    [SerializeField]
    Image rateImage;
    [SerializeField]
    GameObject parentObj;
	void Start ()
    {
        GachaManager manager = new GachaManager(rateImage, parentObj);
        TiketManager ticket = new TiketManager();
	}
}
