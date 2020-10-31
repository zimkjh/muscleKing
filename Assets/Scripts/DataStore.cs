using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    private int health = 0;

    void Awake()
    {
        health = PlayerPrefs.GetInt("health");
    }

    public void incHealthCount(int incNum)
    {
        health += incNum;
        setHealthCount(health);
    }

    public void setHealthCount(int health)
    {
        PlayerPrefs.SetInt("health", health);
    }
    public int getHealthCount()
    {
        return health;
    }
}
