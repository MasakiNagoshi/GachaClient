//////////////////////////////////////////////////
//制作者　名越大樹
//石のを管理するクラス
//////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;
using Protocol;
using HTTP;

public class StoneManager
{
    const string FILE_NAME = "UI/Mark";
    const string MASTER_TYPE = "master";
    static StoneManager instance;
    static List<StoneItemParamater> stoneList = new List<StoneItemParamater>();
    StoneItemMaster master;
    public List<StoneItemParamater> StoneList { get { return stoneList; } }

    public static StoneManager Instance
    {
        get
        {
            return instance;
        }
    }

    public StoneManager(StoneItemMaster setMaster)
    {
        master = setMaster;
        instance = this;
        CanvasManager manager = new CanvasManager();
        ConfirmationStoneManager confirmation = new ConfirmationStoneManager();
        ScrollViewManager.Instance.Find();
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
        var obj = Resources.Load<GameObject>(FILE_NAME);
        foreach (StoneItemParamater stone in stoneList)
        {
            if (stone.Type == MASTER_TYPE)
            {
                stone.MasterStone();
            }
            else
            {
                var instanceObj = master.InstanceObj(obj);
                stone.Instance(instanceObj);
            }
        }
    }
}
