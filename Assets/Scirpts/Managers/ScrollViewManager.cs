using UnityEngine;

public class ScrollViewManager
{
    static ScrollViewManager instance;
    GameObject scrollViewObj;
    GameObject contentObj;
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
        scrollViewObj = GameObject.Find("Scroll View");
        contentObj = GameObject.Find("Content");
    }
}
