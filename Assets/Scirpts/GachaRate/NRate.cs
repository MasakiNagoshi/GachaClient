using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NRate : GachaRate
{
	public void Instance(Image instanceobj,GameObject parent,bool duplication)
	{
		var obj = Instantiate(instanceobj);
		obj.transform.parent = parent.transform;
		if (duplication) 
		{
			obj.color  = Color.black;
		}
		else
		{
			obj.color = Color.red;
		}
	}
}
