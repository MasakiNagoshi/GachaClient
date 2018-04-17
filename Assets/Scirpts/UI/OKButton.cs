using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTTP;
using Protocol;

public class OKButton : MonoBehaviour
{
    Text inputName;
    void Start ()
    {
        GameObject text = GameObject.Find("InputName");
        inputName = text.GetComponent<Text>();
        Debug.Log(inputName);
	}

    public void OK()
    {
        bool result = ErrorCheck.InputName(name);
        Debug.Log(inputName.text.Length);
        if(result)
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
