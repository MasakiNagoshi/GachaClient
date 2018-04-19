/////////////////////////////////////////
//製作者　名越大樹
//レアレートのキャラクターのクラス
/////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public  class RRate : GachaRate
{
	public override void Instance(Image instanceobj,GameObject parent,bool duplication,string dictionary)
    {
        var obj = Instantiate(instanceobj);
        obj.transform.parent = parent.transform;
		if (duplication) 
		{
			obj.color = Color.black;
		} 
		else 
		{
			obj.color = Color.blue;
		}
    }
}
