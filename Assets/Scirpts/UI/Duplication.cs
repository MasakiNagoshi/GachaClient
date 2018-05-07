//////////////////////////////////////////////
//制作者　名越大樹
//排出されたキャラクターが初めて取得した時のクラス
//////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class Duplication
{
    const string DUPLICATION_OBJ = "Duplication";
    const string NEW_IMAGE_FILE = "Image/New";

    public Duplication(GameObject parent)
    {
        GameObject obj = new GameObject(DUPLICATION_OBJ);
        obj.transform.parent = parent.transform;
        obj.AddComponent<Image>().sprite = Resources.Load<Sprite>(NEW_IMAGE_FILE);
        obj.transform.position = parent.transform.position;
    }
}
