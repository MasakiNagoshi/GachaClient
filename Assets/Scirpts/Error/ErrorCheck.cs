////////////////////////////////////////////
//製作者　名越大樹
//ゲーム内のエラー内容に対するクラス
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorCheck
{
    static ErrorCheck instance;

    public static ErrorCheck Instance
    {
        get
        {
            if (instance == null)
            {
                ErrorCheck errorcheck = new ErrorCheck();
                instance = errorcheck;
            }
            return instance;
        }
    }
	
    public static bool InputName(string name)
    {
        Debug.Log(name.Length);
        if (name.Length == 0)
        {
            Debug.Log("名前が入力されていません");
            return false;
        }
        return true;
    }

    public bool CheckAddUseCount(int usecount, int maxcount)
    {
        if (usecount >= maxcount)
        {
            return false;
        }
        else if (usecount <= 0)
        {
            return false;
        }
        return true;
    }
}
