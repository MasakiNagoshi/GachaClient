using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneItemMaster : MonoBehaviour
{
    void Start()
    {
        StoneManager manger = new StoneManager(this);
    }

    public GameObject InstanceObj(GameObject obj)
    {
        var instanceObj = Instantiate(obj,transform.position,Quaternion.identity);
        return instanceObj;
    }
}
