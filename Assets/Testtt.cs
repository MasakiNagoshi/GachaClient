using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Testtt : MonoBehaviour {

    [SerializeField]
    Canvas test;
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            GetEffectManager.Instace.PlayEffect(151);
        }
	}
}
