using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationStoneParamater
{
    string attachItemName;
    int number;
    int buyCount = 1;

    public string AttachItemName { get { return attachItemName; } }
    public int Number { get { return number; } }

    public ConfirmationStoneParamater(string setAttachItemName, int setNumber, Sprite setImage)
    {
        var numberText = GameObject.Find("NumberText").GetComponent<Text>();
        var targetNameText = GameObject.Find("AttachItemText").GetComponent<Text>();
        var targetImage = GameObject.Find("AttachImage").GetComponent<Image>();
        targetNameText.text = setAttachItemName;
        targetImage.sprite = setImage;
        numberText.text = setNumber.ToString();
        attachItemName = setAttachItemName;
        number = setNumber;
    }
}
