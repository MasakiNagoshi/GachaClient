﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicitonaryName
{
    static DicitonaryName instance;
    public static DicitonaryName Instance
    {
        get
        {
            if (instance == null)
            {
                DicitonaryName dictionary = new DicitonaryName();
            }
            return instance;
        }
    }
    DicitonaryName()
    {
        instance = this;
    }
    public string GetName(int number)
    {
        switch (number)
        {
            case 144:
                return "フリーザー";
            case 146:
                return "ファイアー";
        }
        return null;
    }
}