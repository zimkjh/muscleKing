using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BigIntegerController : MonoBehaviour
{
    public string stringAddFunction(string string_1, string string_2)
    {
        return arrAddFunction(stringToArr(string_1), stringToArr(string_2));
    }
    List<int> stringToArr(string string_1)
    {
        List<int> arr_1 = new List<int>();
        for (int i = string_1.Length - 1; i >= 0; i--)
        {
            arr_1.Add(Convert.ToInt32(new string(string_1[i], 1)));
        }
        //Debug.Log("ARRRRR" + string.Join("", arr_1));
        return arr_1;
    }
    string arrAddFunction(List<int> arr_1, List<int> arr_2)
    {
        List<int> arr_3 = new List<int>();
        int upperNum = 0;
        for (int i = 0; i < Math.Min(arr_1.Count, arr_2.Count); i++)
        {
            int temp_1 = arr_1[i] + arr_2[i] + upperNum;
            if (temp_1 >= 10)
            {
                upperNum = 1;
                arr_3.Add(temp_1 - 10);
            }
            else
            {
                upperNum = 0;
                arr_3.Add(temp_1);
            }
        }
        if (arr_1.Count == arr_2.Count)
        {
            return reverseOrder(string.Join("", arr_3));
        }
        else if (arr_1.Count > arr_2.Count)
        {
            for (int i = arr_2.Count; i < arr_1.Count; i++)
            {
                int temp_2 = arr_1[i] + upperNum;
                if (temp_2 >= 10)
                {
                    upperNum = 1;
                    arr_3.Add(temp_2 - 10);
                }
                else
                {
                    upperNum = 0;
                    arr_3.Add(temp_2);
                }
            }
        }
        else
        {
            for (int i = arr_1.Count; i < arr_2.Count; i++)
            {
                int temp_2 = arr_2[i] + upperNum;
                if (temp_2 >= 10)
                {
                    upperNum = 1;
                    arr_3.Add(temp_2 - 10);
                }
                else
                {
                    upperNum = 0;
                    arr_3.Add(temp_2);
                }
            }
        }

        return reverseOrder(string.Join("", arr_3));
    }
    string reverseOrder(string string_1)
    {
        string result = "";
        for (int i = string_1.Length - 1; i >= 0; i--)
        {
            result = result + string_1[i];
        }
        return result;
    }
}
