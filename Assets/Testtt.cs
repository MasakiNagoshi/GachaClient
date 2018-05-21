using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Protocol;
using HTTP;

public class Testtt : MonoBehaviour {

    [SerializeField]
    Canvas test;
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //            GetEffectManager.Instace.PlayEffect(3);
            RequestGetAllStones param = new RequestGetAllStones();
            param.user_id = PlayerPrefs.GetString("id");
            ApiClient.Instance.RequestGetAllStones(param);
        }

        else if(Input.GetKeyDown(KeyCode.A))
        {
           Debug.Log(PlayerPrefs.GetString(NetWorkKey.USER_ID));
        }
	}
}
