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
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add(NetWorkKey.GET_REQUEST, NetWorkKey.TICKET);
            data.Add(NetWorkKey.STATUS, "1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// ガチャチケットを取得するレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseGetGachaTicket(ResponseGetGachaTicket response)
        {
            NormalTicket.Instance.Count = int.Parse(response.noraml);
            NormalTicket.Instance.Ticket.text = "X" + response.noraml;
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
            data.Add(NetWorkKey.USER_ID, param.user_ip);
            data.Add(NetWorkKey.GET_REQUEST, NetWorkKey.LOGIN);
            data.Add(NetWorkKey.STATUS, "1");
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// ログインのレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseLogin(ResponseLogin response)
        {
            if (response.islogin)
            {
                SceneManagers.SceneLoad(SceneManagers.SceneName.Main);
            }

            else
            {
                PlayerPrefs.SetString(NetWorkKey.LOGIN_PRESENT, response.login_present);
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
            SceneManagers.SceneLoad(SceneManagers.SceneName.Title);
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
            data.Add(NetWorkKey.USE_NORMAL, param.used_noraml_ticket);
            data.Add(NetWorkKey.USE_SPECAL, param.used_specal_ticket);
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// ガチャをするときのレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseGacha(ResponseGacha response)
        {
            foreach (EmmisionCharacter character in response.emmisionCharacterList)
            {
                GachaRateInstance.Instance.GachaRate(character.rate, character.dictionary_number, character.duplication);
            }
            Canvas canvas = CanvasManager.Canvas.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            GetEffectManager manager = new GetEffectManager();
        }

        /// <summary>
        /// すべての石の情報を取得するリクエスト処理
        /// </summary>
        /// <param name="param"></param>
        public void RequestGetAllStones(RequestGetAllStones param)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add(NetWorkKey.GET_REQUEST, "stones");
            data.Add(NetWorkKey.STATUS, "1");
            res = ResposeGetAllStones;
            StartCoroutine(requester.RequestPost(ip, data));
        }

        public delegate void DelegateResponseGetAllStone(ResponseGetAllStones response);
        public event DelegateResponseGetAllStone res;

        public void ResponseGetAllStone(ResponseGetAllStones response)
        {
            res(response);
        }

        /// <summary>
        /// 全石の情報を取得したレスポンス処理
        /// </summary>
        /// <param name="response"></param>
        void ResposeGetAllStones(ResponseGetAllStones response)
        {
            if (!StoneManager.Instance.IsIni)
            {
                StoneManager.Instance.UpdateStoneList(response.stones_list);
                return;
            }
            foreach (Stone stone in response.stones_list)
            {
                StoneItemParamater param = new StoneItemParamater(stone.count, stone.type);
                StoneManager.Instance.StoneList.Add(param);
            }
            StoneManager.Instance.Instantiate();
        }

        /// <summary>
        /// 石を購入する時のリクエストに関する処理
        /// </summary>
        /// <param name="param"></param>
        public void RequestBuyStoneItem(RequestBuyStoneItem param)
        {
            Debug.Log("sahosahosah");
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(NetWorkKey.USER_ID, param.user_id);
            data.Add(NetWorkKey.STATUS, "2");
            data.Add(NetWorkKey.TYPE, param.type);
            data.Add(NetWorkKey.TYPE_COUNT, param.count);
            StartCoroutine(requester.RequestPost(ip, data));
        }

        /// <summary>
        /// 石を購入する時のレスポンスに関する処理
        /// </summary>
        /// <param name="response"></param>
        public void ResponseBuyStoneItem(ResponseBuyStoneItem response)
        {
            RequestGetAllStones param = new RequestGetAllStones();
            param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
            RequestGetAllStones(param);
        }
    }
}
