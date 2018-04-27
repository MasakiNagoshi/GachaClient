using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALLDELETE : MonoBehaviour
{
	void Start ()
    {
        PlayerPrefs.DeleteAll();
	}
}
