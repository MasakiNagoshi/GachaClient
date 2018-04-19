////////////////////////////////////////
//製作者　名越大樹
//ノーマルレートのキャラクターのクラス
////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class NRate : GachaRate
{
	public override void Instance(Image instanceobj,GameObject parent,bool duplication,string dictionary)
	{
		var obj = Instantiate(instanceobj);
		obj.transform.parent = parent.transform;
        GameObject character = new GameObject("Character");
        character.AddComponent<Image>();
        character.GetComponent<Image>().sprite = EmmisionGachaIllustlation.Instance.GetIllust(int.Parse(dictionary));
        character.transform.parent = obj.transform;
        character.transform.position = Vector3.zero;
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
