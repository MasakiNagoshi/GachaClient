//////////////////////////////////////////////////
//制作者　名越大樹
//取得したキャラクターを表示させるクラス
//////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Protocol;
using HTTP;

public class DictionaryLibrary : MonoBehaviour
{
    [SerializeField]
    int maxCount;
    [SerializeField]
    Button libraryObj;
    [SerializeField]
    GameObject parentObj;
    const string IMAGE_FOLDER = "Image/Dictionary/";
    const string SE_FOLDER = "SE/Cry/";
    public static DictionaryLibrary instance;
    public List<Button> instanceobjList = new List<Button>();

    void Start()
    {
        instance = this;
        AllGetNumbers();
    }

    IEnumerator InstanceLibrary(List<int> getnumbers)
    {
        for (int count = 0; maxCount > count; count++)
        {
            Button instance = Instantiate(libraryObj);
            yield return null;
            instance.transform.parent = parentObj.transform;
            instanceobjList.Add(instance);
            string number = "";
            int countNumber = count + 1;
            if (countNumber < 10)
            {
                number += "00" + countNumber.ToString();
            }
            else if (countNumber < 100)
            {
                number += "0" + countNumber.ToString();
            }
            else
            {
                number = countNumber.ToString();
            }
            Image image = instanceobjList[countNumber - 1].GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(IMAGE_FOLDER + number);
        }
        foreach (int index in getnumbers)
        {
            Image image = instanceobjList[index - 1].GetComponent<Image>();
            instanceobjList[index - 1].onClick.AddListener(() =>
            {
                SetCrySE(index);
            });

            image.color = Color.white;
        }
        yield return null;
    }

    public void SetCrySE(int index)
    {
        AudioSource source = instanceobjList[index - 1].GetComponent<AudioSource>();
        source.clip = Resources.Load<AudioClip>(SE_FOLDER + index.ToString());
        source.Play();
    }

    public IEnumerator Check(List<int> getnumbers)
    {
        StartCoroutine(InstanceLibrary(getnumbers));
        yield return null;
    }

    void AllGetNumbers()
    {
        RequestGetDictionary param = new RequestGetDictionary();
        param.user_id = PlayerPrefs.GetString(NetWorkKey.USER_ID);
        ApiClient.Instance.RequestGetDictionary(param);
    }
}
