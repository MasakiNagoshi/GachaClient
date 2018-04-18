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
        ApiClient() { }

        void Awake()
        {
            requester = new HTTPRequest(this);
            DontDestroyOnLoad(this);
        }

        public static ApiClient Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject(ObjectName.API_CLIENT);
                    instance = obj.AddComponent<ApiClient>();
                    ip = NetWorkKey.URL;
                }
                return instance;
            }
        }

        /// <summary>
        /// 取得している図鑑の情報を取得するリクエスト処理
        /// </summary>
        /// <param name="param"></param>
        public void RequestGetDictionary(RequestGetDictionary param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add(NetWorkKey.GET_REQUEST, NetWorkKey.DICTIONARY);
            data.Add(NetWorkKey.STATUS, "1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// 取得している図鑑の情報を取得するレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseGetDictionary(ResponseGetDictionary response)
        {
            Debug.Log(response.numbers);
            string[] splitdata = response.numbers.Split(NetWorkKey.DICTIONARY_SPLIT_FONT);
            List<int> numbers = new List<int>();
            for (int index = 0; index < splitdata.Length - 1; index++)
            {
                int castint = int.Parse(splitdata[index]);
                Debug.Log(splitdata[index]);
                numbers.Add(castint);
            }
            StartCoroutine(DictionaryLibrary.instance.Check(numbers));
        }

        /// <summary>
        /// ガチャチケットを取得するリクエスト処理
        /// </summary>
        /// <param name="param"></param>
        public void RequestGetGachaTiket(RequestGetGachaTicket param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.USER_ID,param.user_id);
            data.Add(NetWorkKey.GET_REQUEST, NetWorkKey.TICKET);
            data.Add(NetWorkKey.STATUS,"1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// ガチャチケットを取得するレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseGetGachaTicket(ResponseGetGachaTicket response)
        {
            NormalTicket.Instance.Count = int.Parse(response.noraml);
            NormalTicket.Instance.Ticket.text = "☓" + response.noraml;
            SpecalTicket.Instance.Count = int.Parse(response.specal);
            SpecalTicket.Instance.Ticket.text = "X" + response.specal;
        }

        /// <summary>
        /// ログインをするリクエスト処理
        /// </summary>
        /// <param name="param"></param>
        public void RequestLogin(RequestLogin param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.USER_ID,param.user_ip);
            data.Add(NetWorkKey.GET_REQUEST,NetWorkKey.LOGIN);
            data.Add(NetWorkKey.STATUS,"1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// ログインのレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseLogin(ResponseLogin response)
        {
            if(response.islogin)
            {
                Debug.Log("ログインしていました");
                SceneManagers.SceneLoad( SceneManagers.SceneName.Main);
            }

            else
            {
                Debug.Log("ログインまだでした");
                PlayerPrefs.SetString(NetWorkKey.LOGIN_PRESENT,response.login_present);
                SceneManagers.SceneLoad(SceneManagers.SceneName.LoginPresent);
            }
        }

        /// <summary>
        /// 新規ユーザーを作成のリクエスト処理
        /// </summary>
        /// <param name="param"></param>
        public void RequestCreateUser(RequestCreateUser param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.REQUEST_STATUS, NetWorkKey.CREATE_USER);
            data.Add(NetWorkKey.USER_NAME, param.user_name);
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// 新規ユーザを作成のレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseCreateUser(ResponseCreateUser response)
        {
            PlayerPrefs.SetString(NetWorkKey.USER_ID, response.user_id);
            PlayerPrefs.SetString(NetWorkKey.USER_NAME, response.user_name);
            Debug.Log("ユーザー登録完了");
        }

        /// <summary>
        ///　ガチャをするときのリクエスト処理
        /// </summary>
        /// <param name="param"></param>
        public void RequesrGacha(RequestGacha param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.GACHA_RATE, param.status);
            data.Add(NetWorkKey.GACHA_LIMIT, param.limit);
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add(NetWorkKey.REQUEST_STATUS, NetWorkKey.GACHA);
			data.Add(NetWorkKey.USE_NORMAL,param.used_noraml_ticket);
			data.Add(NetWorkKey.USE_SPECAL, param.used_specal_ticket);
			Debug.Log (param.status);
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// ガチャをするときのレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseGacha(ResponseGacha response)
        {
            foreach(EmmisionCharacter character in response.emmisionCharacterList)
            {
				GachaRate rate = new GachaRate(character.rate,character.dictionary_number,character.duplication);
            }
        }
    }
}
