using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    static float healthMulRate;
    Dictionary<string, int> healthDict = new Dictionary<string, int>();
    void Awake()
    {
        healthMulRate = 1;
        if (PlayerPrefs.HasKey("healthMulRate"))
        {
            healthMulRate = PlayerPrefs.GetFloat("healthMulRate");
        }
        List<string> healthNameList = new List<string>();
        healthNameList.Add("health");
        healthNameList.Add("healthPerTouch");
        healthNameList.Add("healthPerSecond");
        foreach (string name in healthNameList)
        {
            if (PlayerPrefs.HasKey(name))
            {
                healthDict[name] = PlayerPrefs.GetInt(name);
            }
            else
            {
                healthDict[name] = 1;
            }
        }
        StartCoroutine(healthUpPerSecond());
    }
    IEnumerator healthUpPerSecond()
    {
        while (true)
        {
            incHealth("health", Convert.ToInt32(healthDict["healthPerSecond"] * healthMulRate));
            yield return new WaitForSeconds(1f);
        }
    }
    public void incHealth(string healthName, int incNum)
    {
        healthDict[healthName] += incNum;
        setHealth(healthName, healthDict[healthName]);
    }
    public void setHealth(string healthName, int health)
    {
        PlayerPrefs.SetInt(healthName, health);
    }
    public void decHealth(string healthName, int decNum)
    {
        healthDict[healthName] -= decNum;
        setHealth(healthName, healthDict[healthName]);
    }
    public int getHealth(string healthName)
    {
        return healthDict[healthName];
    }
    public void mulHealth(float mulNum)
    {
        healthMulRate = healthMulRate * mulNum;
        PlayerPrefs.SetFloat("healthMulRate", healthMulRate);
    }
    public float getMulHealth()
    {
        return healthMulRate;
    }
}
