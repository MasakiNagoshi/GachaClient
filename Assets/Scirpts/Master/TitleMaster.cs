/////////////////////////////////////////
//製作者　名越大樹
//Titleシーン全体を管理するクラス
/////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMaster : MonoBehaviour
{
    public static TitleMaster master;
	void Start ()
    {
        master = this;
        TitleManager manager = new TitleManager();
	}
}
