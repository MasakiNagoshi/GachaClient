//////////////////////////////////////////////
//制作者　名越大樹
//新規ユーザーを作成する時のOKボタンに関するクラス
///////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using HTTP;
using Protocol;

public class OKButton : MonoBehaviour
{
    Text inputName;
    const string INPUT_NAME_OBJ = "InputName";

    void Start()
    {
        GameObject text = GameObject.Find(INPUT_NAME_OBJ);
        inputName = text.GetComponent<Text>();
    }

    public void OK()
    {
        bool result = ErrorCheck.InputName(name);
        if (result)
        {
            CreateUser();
        }
    }

    void CreateUser()
    {
        RequestCreateUser param = new RequestCreateUser();
        param.user_name = inputName.text;
        ApiClient.Instance.RequestCreateUser(param);
    }
}
