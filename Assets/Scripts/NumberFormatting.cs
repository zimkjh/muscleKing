using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NumberFormatting : MonoBehaviour
{
    string[] numbering = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public string formatting(int num)
    {
        
        int order = 1000;
        int index = -1;
        int temp = num;
        while(temp >= 1000)
        {
            temp = temp / order;
            index = index + 1;
        }
        float result = (float)Math.Round((float)num / (float)(Math.Pow(order, (index+1))), 1);
        string result_string = num.ToString();
        if (index != -1 & index <= 25)
        {
            result_string = result.ToString() + numbering[index];
        }
        if(index >= 26) //26 AA 27 AB ... 52 BA ... 78 CA
        {
            int first = (index / 26) -1;
            int second = index - ((first+1)*26);
            result_string = result.ToString() + numbering[first] + numbering[second];
        }
        return result_string;
    }
}
