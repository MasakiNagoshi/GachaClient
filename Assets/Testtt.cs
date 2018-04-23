using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Testtt : MonoBehaviour {

    [SerializeField]
    Canvas test;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            GetEffectManager.Instace.PlayEffect(146);

            Debug.Log(Resources.Load<Sprite>("Image/CharacterIllust/SSRRateImage/" + 146));
        }
	}
}
