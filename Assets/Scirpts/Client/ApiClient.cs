//////////////////////////////////////////////
//製作者　名越大樹
//HTTP通信を行う処理に関するクラス
//////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;
using Request;
using Protocol;

namespace HTTP
{
    public class ApiClient : MonoBehaviour
    {
        static ApiClient instance;
        HTTPRequest requester;
        static string ip;
        void Awake()
        {
            requester = new HTTPRequest(this);
            DontDestroyOnLoad(this);
        }
        ApiClient() { }

        public static ApiClient Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject("ApiClientObj");
                    instance = obj.AddComponent<ApiClient>();
                    ip = NetWorkKey.URL;
                }
                return instance;
            }
        }

        public void RequestGetDictionary(RequestGetDictionary param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add("getrequest","dictionary");
            data.Add("status", "1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        public void ResponseGetDictionary(ResponseGetDictionary response)
        {
            Debug.Log(response.numbers);
            string[] splitdata = response.numbers.Split('/');
            List<int> numbers = new List<int>();
            for (int index = 0; index < splitdata.Length - 1; index++)
            {
                int castint = int.Parse(splitdata[index]);
                Debug.Log(splitdata[index]);
                numbers.Add(castint);
            }
            StartCoroutine(DictionaryLibrary.instance.Check(numbers));
        }

        public void RequestGetGachaTiket(RequestGetGachaTicket param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id",param.user_id);
            data.Add("getrequest","ticket");
            data.Add("status","1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        public void ResponseGetGachaTicket(ResponseGetGachaTicket response)
        {
            NormalTicket.Ticket.text = response.noraml;
            SpecalTicket.Ticket.text = response.specal;
        }


        public void RequestLogin(RequestLogin param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id",param.user_ip);
            data.Add("getrequest","login");
            data.Add("status","1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        public void ResponseLogin(ResponseLogin response)
        {
            Debug.Log(response.islogin);
        }

        public void RequestCreateUser(RequestCreateUser param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.REQUEST_STATUS, NetWorkKey.CREATE_USER);
            data.Add(NetWorkKey.USER_NAME, param.user_name);
            StartCoroutine(requester.RequestPost(ip, data));
        }

        public void ResponseCreateUser(ResponseCreateUser response)
        {
            PlayerPrefs.SetString(NetWorkKey.USER_ID, response.user_id);
            PlayerPrefs.SetString(NetWorkKey.USER_NAME, response.user_name);
        }

        public void RequesrGacha(RequestGacha param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.GACHA_RATE, param.status);
            data.Add(NetWorkKey.GACHA_LIMIT, param.limit);
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add(NetWorkKey.REQUEST_STATUS, NetWorkKey.GACHA);
            StartCoroutine(requester.RequestPost(ip, data));
        }

        public void ResponseGacha(ResponseGacha response)
        {
            foreach(EmmisionCharacter character in response.emmisionCharacterList)
            {
                GachaRate rate = new GachaRate(character.rate);
            }
        }
    }
}
