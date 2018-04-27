//////////////////////////////////////////////
//製作者　名越大樹
//リクエストとレスポンスを行うクラス
///////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Protocol;
using HTTP;

namespace Request
{
    public class HTTPRequest
    {
        static HTTPRequest instance;
        MonoBehaviour mono;
        public HTTPRequest(MonoBehaviour monoBehaviour)
        {
            mono = monoBehaviour;
        }

        public IEnumerator RequestPost(string url, Dictionary<string, string> dic)
        {
            WWWForm form = new WWWForm();
            foreach (var data in dic)
            {
                form.AddField(data.Key, data.Value);
            }
            WWW www = new WWW(url, form);
            yield return www;

            if (www.error == null)
            {
                Debug.Log(www.text);
                ResponsePost(www.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }

        void ResponsePost(string response)
        {
            string[] splitdata = response.Split(NetWorkKey.RESPONSE_FIRST_SPLIT);
            switch (splitdata[0])
            {
                case NetWorkKey.RESPONSE_CREATE_USER:
                    ResponseCreateUser(splitdata);
                    break;
                case NetWorkKey.RESPONSE_GET_DICTIONARY:
                    ResponseGetDictionary(splitdata);
                    break;
                case NetWorkKey.RESPONSE_GACHA:
                    ResponseGacha(splitdata);
                    break;
                case NetWorkKey.RESPONSE_GET_GACHA_TICKET:
                    ResponseGetGachaTiket(splitdata);
                    break;
                case NetWorkKey.RESPONSE_GET_LOGIN:
                    ResponseGetLogin(splitdata);
                    break;
            }
        }

        void ResponseGetLogin(string[] data)
        {
            ResponseLogin response = new ResponseLogin();
            if (data[1] == "0")
            {
                response.islogin = false;
                response.login_present = data[2];
                Debug.Log(data[2]);
            }
            else
            {
                response.islogin = true;
            }
            ApiClient.Instance.ResponseLogin(response);
        }

        void ResponseGetGachaTiket(string[] data)
        {
            List<string> sortdata = new List<string>(data);
            sortdata.RemoveAt(0);
            ResponseGetGachaTicket response = new ResponseGetGachaTicket();
            for (int count = 0; count < sortdata.Count; count++)
            {
                string[] splitdata = sortdata[count].Split(NetWorkKey.SPLIT_TICKET_FONT);
                switch (splitdata[0])
                {
                    case NetWorkKey.NORMAL_TICKET:
                        response.noraml = splitdata[1];
                        break;
                    case NetWorkKey.SPECAL_TICKET:
                        response.specal = splitdata[1];
                        break;
                }
            }
            ApiClient.Instance.ResponseGetGachaTicket(response);
        }

        void ResponseGetDictionary(string[] data)
        {
            ResponseGetDictionary response = new ResponseGetDictionary();
            response.numbers = data[1];
            Debug.Log(data[1]);
            ApiClient.Instance.ResponseGetDictionary(response);
        }

        void ResponseCreateUser(string[] data)
        {
            ResponseCreateUser response = new ResponseCreateUser();
            response.user_id = data[1];
            response.user_name = data[2];
            ApiClient.Instance.ResponseCreateUser(response);
        }

        void ResponseGacha(string[] data)
        {
            List<string> sort = new List<string>(data);
            sort.RemoveAt(0);
            ResponseGacha response = new Protocol.ResponseGacha();
            for (int count = 0; count < sort.Count - 1; count++)
            {
                string[] splitdata = sort[count].Split(NetWorkKey.EMMISION_CHARACTER_FONT);
                EmmisionCharacter emmision = new EmmisionCharacter();
                emmision.dictionary_number = splitdata[0];
                emmision.rate = splitdata[1];
                if (splitdata[2] == NetWorkKey.DUPLICATION)
                {
                    emmision.duplication = true;
                }
                else
                {
                    emmision.duplication = false;
                }
                response.emmisionCharacterList.Add(emmision);
            }
            ApiClient.Instance.ResponseGacha(response);
        }
    }
}
