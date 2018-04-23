using UnityEngine;
using UnityEngine.UI;

public class GetEffectBase : MonoBehaviour
{
    int number;
    public GetEffectBase()
    {

    }

    public virtual void ShowCharacter(int number)
    {
        Image image = GetEffectManager.Instace.CharacterImage;
        image.sprite = Resources.Load<Sprite>("Image/CharacterIllust/SSRRateImage/" + number);
        image.color = Color.white;
        ScaleAnimationManager.Instance.CreateScaleAnimation(image.gameObject);
    }

    public virtual void ShowName(int number)
    {
        Text text = GetEffectManager.Instace.CharacterText;
        string name = DicitonaryName.Instance.GetName(number);
        text.text = name;
    }

    public GetEffectBase(int dictionary)
    {
        number = dictionary;
        Debug.Log(number);
        Debug.Break();
    }
    public virtual void PlayeCharacterCrySe(int number)
    {
        AudioSource audio = GetEffectManager.Instace.Audio;
        AudioClip clip = Resources.Load<AudioClip>("SE/Cry/" + number);
        audio.clip = clip;
        audio.Play();
    }

    public virtual  void Ini()
    {
        GetEffectManager.Instace.ChangeCanvas();
        
    }

    public virtual int GetNumber()
    {
        return number;
    }

    public virtual void PlaySe()
    {

    }

    public virtual void EffectUpdate()
    {
    }

    public virtual bool IsClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
}
