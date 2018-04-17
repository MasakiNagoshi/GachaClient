using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmisionGachaManager
{
    static GameObject emmisonCharacteresParent;
    public EmmisionGachaManager()
    {
        GameObject obj = GameObject.Find("EmmisionParent");
        emmisonCharacteresParent = obj;
        AttachRate.AttachGachaRate.Gacha();
    }

    public static GameObject EmmisonCharacteresParent { get { return emmisonCharacteresParent; } }
}
