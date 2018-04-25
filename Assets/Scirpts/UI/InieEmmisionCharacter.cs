///////////////////////////////////////
//制作者　名越大樹
//排出したキャラクターの初めて入手したキャラクターに関するクラス
////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniEmmisionCharacter
{
    public IniEmmisionCharacter(GameObject parent)
    {
        GameObject obj = new GameObject("Duplication");
        obj.transform.parent = parent.transform;
        obj.transform.localScale = new Vector3(1,1,1);
        obj.AddComponent<Image>().sprite = Resources.Load<Sprite>("Image/New");
        obj.transform.position = parent.transform.position;
    }
}
