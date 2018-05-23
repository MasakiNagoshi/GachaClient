/////////////////////////////////////////////////////
//制作者　名越大樹
//
/////////////////////////////////////////////////////

using UnityEngine;

public class StoneMaster : MonoBehaviour
{
    void Start()
    {
        StoneManager manger = new StoneManager(this);
    }

    public GameObject InstanceObj(GameObject obj)
    {
        var instanceObj = Instantiate(obj,transform.position,Quaternion.identity);
        return instanceObj;
    }
}
