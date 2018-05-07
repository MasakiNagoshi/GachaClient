using UnityEngine;
using UnityEngine.UI;

public class ErrorUI : MonoBehaviour
{
     Text errorText;
    static GameObject instanceObj;
    static Button button;

    public ErrorUI(string error)
    {
        Instance();
        ErrorMeesage(error);
        AnimationSetting();
    }

    void AnimationSetting()
    {
        ScaleAnimationManager.Instance.CreateScaleAnimation(instanceObj, 6.0f);
        UpdateAnimationManager.Instance.AnimationStart();
        button.GetComponent<Image>().color = Color.red;
    }

    void Instance()
    {
        GameObject obj = Resources.Load<GameObject>("UI/ErrorUI");
        instanceObj = Instantiate(obj, Vector2.zero, Quaternion.identity);
        instanceObj.transform.parent = CanvasManager.Canvas.transform;
        instanceObj.transform.localPosition = Vector3.zero;
        errorText = GameObject.Find("ErrorText").GetComponent<Text>();
        button = GameObject.Find("ErrorButton").GetComponent<Button>();
        AddLisner();
    }

    void AddLisner()
    {
        button.onClick.AddListener(() => Destroy(instanceObj));
    }

    void ErrorMeesage(string error)
    {
        errorText.text = error;
    }
}
