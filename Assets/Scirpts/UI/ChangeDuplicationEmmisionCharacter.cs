using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDuplicationEmmisionCharacter : ChangeAnimation
{

    bool isUpdate = true;
    float count;
    Image changeImage;
    string rate;

    public ChangeDuplicationEmmisionCharacter(float setCount,Image setImage,string setRate)
    {
        count = setCount;
        changeImage = setImage;
        ChangeAnimationManager.Instance.ChangeAnimationAdd(this);
        rate = setRate;
    }

    public override void UpdateCount()
    {
        if(!isUpdate)
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
        changeImage.sprite = Resources.Load<Sprite>("Image/Type/master");
        InstanceText(rate);
    }

    void InstanceText(string rate)
    {
        var textObj = new GameObject();
        textObj.transform.parent = changeImage.transform;
        var text = textObj.AddComponent<Text>();
        switch (rate)
        {
            case "n":
                text.text = "×１";
                break;
            case "r":
                text.text = "×3";
                break;
            case "sr":
                text.text = "×10";
                break;
            case "ssr":
                text.text = "×50";
                break;
        }
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
        text.transform.localScale = new Vector3(2,2,2);
        text.transform.localPosition = Vector3.zero;
    }
}
