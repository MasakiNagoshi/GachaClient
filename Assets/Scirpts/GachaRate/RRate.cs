using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class RRate : GachaRate
{
    public void Instance(Image instanceobj,GameObject parent)
    {
        var obj = Instantiate(instanceobj);
        obj.transform.parent = parent.transform;
        obj.color = Color.blue;
    }
}
