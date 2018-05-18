using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneImageCorrection
{
    public string GetImageFile(string type)
    {
        switch(type)
        {
            case "fire":
                return "mark_1";
            case "ice":
                return "mark_3";

        }
        return "";
    }
}
