///////////////////////////////////////////////////////////////
//制作者　名越大樹
//排出したガチャを全表示させるクラス
///////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButton
{
    static SkipButton instance;
    public static SkipButton Instance { get { return instance; } }
    List<GachaRate> gachaList = new List<GachaRate>();
    Button buttonobj;

    public SkipButton()
    {
        instance = this;
        buttonobj = GameObject.Find("SkipButton").GetComponent<Button>();
    }

    /// <summary>
    /// 排出されたガチャの登録に関するクラス
    /// </summary>
    /// <param name="duplication"></param>
    /// <param name="number"></param>
    /// <param name="targetobj"></param>
    /// <param name="add"></param>
    public void AddSkip(string rate,bool duplication, int number,Button targetobj,GachaRate add)
    {
        buttonobj.onClick.AddListener(() => 
        {
            add.ChangeColor(rate,duplication,number,targetobj);
        }
        );
    }

}
