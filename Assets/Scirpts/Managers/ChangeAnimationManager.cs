///////////////////////////////////////////////
//制作者　名越大樹
//ChangeAnimationを管理するクラス
///////////////////////////////////////////////

using System.Collections.Generic;

public class ChangeAnimationManager
{
    static ChangeAnimationManager instance;
    List<ChangeAnimation> changeAnimationList = new List<ChangeAnimation>();

    public List<ChangeAnimation> ChangeAnimationList { get { return changeAnimationList; } }
    public static ChangeAnimationManager Instance
    {
        get
        {
            if (instance == null)
            {
                var manager = new ChangeAnimationManager();
            }
            return instance;
        }
    }

    public ChangeAnimationManager()
    {
        instance = this;
    }

    public void Update()
    {
        foreach (ChangeAnimation changeAnimation in changeAnimationList)
        {
            changeAnimation.UpdateCount();
        }
    }

    public void ChangeAnimationAdd(ChangeAnimation add)
    {
        changeAnimationList.Add(add);
    }
}
