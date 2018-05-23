//////////////////////////////////////////
//制作者　名越大樹
//スクロールオブジェクトを管理するクラス
//////////////////////////////////////////

using UnityEngine;

public class ScrollViewManager
{
    static ScrollViewManager instance;
    GameObject scrollViewObj;
    GameObject contentObj;
    const string SCROLL_VIEW_OBJ = "Scroll View";
    const string CONTENT_OBJ = "Content";
    public static ScrollViewManager Instance
    {
        get
        {
            if (instance == null)
            {
                ScrollViewManager manager = new ScrollViewManager();
            }
            return instance;
        }
    }
    public GameObject ScrollViewObj { get { return scrollViewObj; } }
    public GameObject Content { get { return contentObj; } }

    public ScrollViewManager()
    {
        instance = this;
    }

    public void Find()
    {
        scrollViewObj = GameObject.Find(SCROLL_VIEW_OBJ);
        contentObj = GameObject.Find(CONTENT_OBJ);
    }
}
