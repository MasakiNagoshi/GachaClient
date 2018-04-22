using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duplication
{
    public Duplication(GameObject parent)
    {
        GameObject obj = new GameObject("Duplication");
        obj.transform.parent = parent.transform;
        obj.AddComponent<Image>().sprite = Resources.Load<Sprite>("Image/New");
        obj.transform.position = parent.transform.position;
    }
}
