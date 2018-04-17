using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPresentMaster : MonoBehaviour
{
    void Start()
    {
        SpriteManager spriteManager = new SpriteManager( SpriteManager.ReadStatus.Tickets);
        LoginPresentManager manager = new LoginPresentManager();
    }
}
