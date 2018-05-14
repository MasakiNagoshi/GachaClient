//////////////////////////////////////////////////////////////
//制作者　名越大樹
//排出したキャラクターの初めて入手したキャラクターに関するクラス
//////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class IniEmmisionCharacter
{
    const string DUPLICATION_OBJ = "Duplication";
    const string NEW_IMAGE_FILE = "Image/New";

    public IniEmmisionCharacter(GameObject parent)
    {
        GameObject obj = new GameObject(DUPLICATION_OBJ);
        obj.transform.parent = parent.transform;
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.AddComponent<Image>().sprite = Resources.Load<Sprite>(NEW_IMAGE_FILE);
        obj.transform.position = parent.transform.position;
    }
}
