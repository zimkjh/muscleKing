using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataController : MonoBehaviour
{
    private int health = 0;
    private int healthPerTouch = 1;
    private int healthPerSecond = 1;
    Dictionary<string, int> healthDict = new Dictionary<string, int>();
    void Awake()
    {
        List<string> healthNameList = new List<string>();
        healthNameList.Add("health");
        healthNameList.Add("healthPerTouch");
        healthNameList.Add("healthPerSecond");
        foreach (sting name in healthNameList)
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
            incHealth("health", healthDict["healthPerSecond"]);
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
}
