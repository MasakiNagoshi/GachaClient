/////////////////////////////////////////////////////////
//制作者　名越大樹
//重複したキャラクターをアイテムに変換させるクラス
////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class ChangeDuplicationEmmisionCharacter : ChangeAnimation
{

    bool isUpdate = true;
    float count;
    Image changeImage;
    string rate;
    const string IMAGE_FILE_NAME = "Image/Type/master";
    const string FONT_FILE_NAME = "Arial.ttf";
    const string N_RATE = "n";
    const string R_RATE = "r";
    const string SR_RATE = "sr";
    const string SSR_RATE = "ssr";
    const int N_VALUE = 1;
    const int R_VALUE = 3;
    const int SR_VALUE = 10;
    const int SSR_VALUE = 50;

    public ChangeDuplicationEmmisionCharacter(float setCount, Image setImage, string setRate)
    {
        count = setCount;
        changeImage = setImage;
        ChangeAnimationManager.Instance.ChangeAnimationAdd(this);
        rate = setRate;
    }

    public override void UpdateCount()
    {
        if (!isUpdate)
        {
            return;
        }
        count -= Time.deltaTime;
        if (count <= 0.0f)
        {
            isUpdate = false;
            ChangeAction();
        }
    }

    public override void ChangeAction()
    {
        changeImage.sprite = Resources.Load<Sprite>(IMAGE_FILE_NAME);
        InstanceText(rate);
    }

    void InstanceText(string rate)
    {
        var textObj = new GameObject();
        textObj.transform.parent = changeImage.transform;
        var text = textObj.AddComponent<Text>();
        string message = "×";
        switch (rate)
        {
            case N_RATE:
                message += N_VALUE.ToString();
                break;
            case R_RATE:
                message += R_VALUE.ToString();
                break;
            case SR_RATE:
                message += SR_VALUE.ToString();
                break;
            case SSR_RATE:
                message += SSR_VALUE.ToString();
                break;
        }
        text.text = message;
        text.font = Resources.GetBuiltinResource(typeof(Font), FONT_FILE_NAME) as Font;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
        text.transform.localScale = new Vector3(2, 2, 2);
        text.transform.localPosition = Vector3.zero;
    }
}
