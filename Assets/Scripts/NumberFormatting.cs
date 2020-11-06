using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NumberFormatting : MonoBehaviour
{
    string[] numbering = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA" };
    public string formatting(int num)
    {
        int order = 1;
        int index = -1;
        while (num >= order * 1000 & num < order * 1000000)
        {
            order = order * 1000;
            index = index + 1;
        }
        float result = (float)Math.Round((float)num / (float)order, 1);
        string result_string = num.ToString();
        if (index != -1)
        {
            result_string = result.ToString() + numbering[index];
        }
        return result_string;
    }
}
