using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCorrection
{
    static NumberCorrection instance;
    public static NumberCorrection Instnce
    {
        get
        {
            if (instance == null)
            {
                NumberCorrection correction = new NumberCorrection();
            }
            return instance;
        }
    }

    public NumberCorrection()
    {
        instance = this;
    }

    public string Correction(int number)
    {
        if(number > 10 && number < 100)
        {
            return "0" + number.ToString();
        }

        else if(number < 10)
        {
            return "00" + number.ToString();
        }
        else
        {
            return number.ToString();
        }
    }


}
