////////////////////////////////////////////////////////////
//制作者　名越大樹
//エラーのUIを表示させるクラス
////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class ErrorUI : MonoBehaviour
{
    Text errorText;
    static GameObject instanceObj;
    static Button button;
    const float ANIMATION_SPEED = 6.0f;
    const string INSTANCE_UI = "UI/ErrorUI";
    const string ERROR_TEXT_OBJ = "ErrorText";
    const string ERROR_BUTTON_OBJ = "ErrorButton";

    public ErrorUI(string error)
    {
        Instance();
        ErrorMeesage(error);
        AnimationSetting();
    }

    void AnimationSetting()
    {
        ScaleAnimationManager.Instance.CreateScaleAnimation(instanceObj, ANIMATION_SPEED);
        ErrorUpdateAnimationManager.Instance.AnimationStart();
        button.GetComponent<Image>().color = Color.red;
    }

    void Instance()
    {
        GameObject obj = Resources.Load<GameObject>(INSTANCE_UI);
        instanceObj = Instantiate(obj, Vector2.zero, Quaternion.identity);
        instanceObj.transform.parent = CanvasManager.Canvas.transform;
        instanceObj.transform.localPosition = Vector3.zero;
        errorText = GameObject.Find(ERROR_TEXT_OBJ).GetComponent<Text>();
        button = GameObject.Find(ERROR_BUTTON_OBJ).GetComponent<Button>();
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
