using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Protocol;
using HTTP;

public class StoneManager : MonoBehaviour
{
    static StoneManager instance;
    List<StoneItemParamater> stoneList;

    public List<StoneItemParamater> StoneList { get { return stoneList; } set { stoneList = value; } }

    public static StoneManager Instance
    {
        get
        {
            if (instance == null)
            {
                var manager = new StoneManager();
            }
            return instance;
        }
    }


    public StoneManager()
    {
        instance = this;
        stoneList = new List<StoneItemParamater>();
        CanvasManager manager = new CanvasManager();
        Request();
    }

    void Request()
    {
        RequestGetAllStones param = new RequestGetAllStones();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        ApiClient.Instance.RequestGetAllStones(param);
    }

    public void Instantiate()
    {
        var obj = Resources.Load<GameObject>("UI/Mark");
        Debug.Log(obj);
        /*
        foreach (StoneItemParamater stone in stoneList)
        {
            if (stone.Type == "master")
            {

            }
            else
            {
                var instanceObj = Instantiate(obj, transform.position, Quaternion.identity);
                stone.Instance(instanceObj);
            }
        }
        */
    }
}
