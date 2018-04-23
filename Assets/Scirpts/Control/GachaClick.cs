using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaClick : MonoBehaviour
{
    [SerializeField]
    LayerMask ballLayer;

	void Update ()
    {
        Click();
	}

    void Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray();
        }
    }

    void Ray()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity,ballLayer);
        if(hit.collider)
        {
            HitBall();
        }
    }

    void HitBall()
    {

    }
}
