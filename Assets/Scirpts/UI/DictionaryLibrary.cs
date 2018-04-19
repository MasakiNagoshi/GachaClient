using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DictionaryLibrary : MonoBehaviour
{
    [SerializeField]
    int maxCount;
    [SerializeField]
    Image libraryObj;
    [SerializeField]
    GameObject parentObj;
    public static DictionaryLibrary instance;
    public List<Image> instanceobjList = new List<Image>();

    void Start ()
    {
        instance = this;
        StartCoroutine(InstanceLibrary());
	}

    IEnumerator InstanceLibrary()
    {
        for (int count = 0; maxCount > count; count++)
        {
            Image instance = Instantiate(libraryObj);
            yield return null;
            instance.transform.parent = parentObj.transform;
            instanceobjList.Add(instance);
        }
        AllGetNumbers.AllGetNumber();
        yield return null;
    }
	public IEnumerator Check(List<int> getnumbers)
    {
        foreach(int index in getnumbers)
        {
            instanceobjList[index].color = Color.red;
        }
        yield return null;
    }
}
