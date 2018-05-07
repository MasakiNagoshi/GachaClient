///////////////////////////////////////
//製作者　名越ぢ秋
//LoginPreentシーン全体を管理するクラス
///////////////////////////////////////

using UnityEngine;

public class LoginPresentMaster : MonoBehaviour
{
    void Start()
    {
        SpriteManager spriteManager = new SpriteManager(SpriteManager.ReadStatus.Tickets);
        LoginPresentManager manager = new LoginPresentManager();
    }
}
