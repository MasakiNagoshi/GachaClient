using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private void Start()
    {
       var instance = Resources.Load<GameObject>("Reset");
       var obj = Instantiate(instance);
       DontDestroyOnLoad(obj);
    }
}
