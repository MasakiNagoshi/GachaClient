using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
