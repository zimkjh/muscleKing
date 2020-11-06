using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    private int allHealth;
    private float muscleVal;
    private float threeWeight;
    private float weight;
    private int drug;
    static float healthMulRate;
    Dictionary<string, int> healthDict = new Dictionary<string, int>();
    void Awake()
    {
        muscleVal = 20;
        threeWeight = 100;
        weight = 40;
        drug = 0;
        if (PlayerPrefs.HasKey("drug"))
        {
            drug = PlayerPrefs.GetInt("drug");
        }
        if (PlayerPrefs.HasKey("muscleVal"))
        {
            muscleVal = PlayerPrefs.GetFloat("muscleVal");
            threeWeight = PlayerPrefs.GetFloat("threeWeight");
            weight = PlayerPrefs.GetFloat("weight");
        }
        allHealth = 0;
        if (PlayerPrefs.HasKey("allHealth"))
        {
            allHealth = PlayerPrefs.GetInt("allHealth");
        }
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
            incAllHealth(Convert.ToInt32(healthDict["healthPerSecond"] * healthMulRate));
            saveInfo();
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
    public float getAllHealth()
    {
        return allHealth;
    }
    public void incAllHealth(int incNum)
    {
        allHealth = allHealth + incNum;
        PlayerPrefs.SetInt("allHealth", allHealth);
    }
    public void saveInfo()
    {
        muscleVal = 20 + (float)Math.Log(getAllHealth(), 2);
        threeWeight = 100 + (float)Math.Log(getAllHealth(), 1.064);
        weight = 40 + (float)Math.Log(getAllHealth(), 1.66);
    }
    public float getMuscleVal()
    {
        return muscleVal;
    }
    public float getThreeWeight()
    {
        return threeWeight;
    }
    public float getWeight()
    {
        return weight;
    }
    public int getDrug()
    {
        return drug;
    }
    public void incDrug(int incNum)
    {
        drug = drug + incNum;
        PlayerPrefs.SetInt("drug", drug);
    }
    public void decDrug(int decNum)
    {
        drug = drug - decNum;
        PlayerPrefs.SetInt("drug", drug);
    }
}
