﻿/////////////////////////////////////////
//制作者　名越大樹
//各シーン上に存在するCanvasを管理するクラス
/////////////////////////////////////////

using UnityEngine;

public class CanvasManager
{
    static GameObject canvas;
    const string CANVAS_NAME = "Canvas";

    public CanvasManager()
    {
        canvas = GameObject.Find(CANVAS_NAME);
    }
    public static GameObject Canvas
    {
        get
        {
            if (canvas == null)
            {
                Find();
            }
            return canvas;
        }
        set { canvas = value; }
    }

    static void Find()
    {
        canvas = GameObject.Find(CANVAS_NAME);
    }
}
