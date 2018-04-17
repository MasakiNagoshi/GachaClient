using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager
{
    static GameObject canvas;
    public CanvasManager()
    {
        canvas = GameObject.Find("Canvas");
    }
    public static GameObject Canvas { get { return canvas; } set { canvas = value; } }
}
