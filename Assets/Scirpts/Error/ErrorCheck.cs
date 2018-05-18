////////////////////////////////////////////
//製作者　名越大樹
//ゲーム内のエラー内容に対するクラス
////////////////////////////////////////////

using UnityEngine;

public class ErrorCheck
{
    static ErrorCheck instance;
    ErrorUI errorUI;
    public enum ErrorStatus
    {
        FailedToConnect,
    }

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
        if (usecount > maxcount)
        {
            return false;
        }

        else if (usecount <= 0)
        {
            return false;
        }

        return true;
    }

    public bool CheckUseCount(int usecount)
    {
        if (usecount == 0)
        {
            return false;
        }
        return true;
    }

    public void HTTPError(string error)
    {
        string message = "";
        if (error == "Failed to connect to 150.95.179.163 port 0: Host unreachable")
        {
            message = "ネットがつながっていませんネット状況を確認してください";
        }
        else
        {
            message = "サーバーのメンテナンス中ですしばらくお待ちください";
        }
        ErrorUI ui = new ErrorUI(message);
        errorUI = ui;
    }

}
