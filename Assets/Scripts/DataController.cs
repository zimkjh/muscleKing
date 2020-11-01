using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private int health = 0;

    void Awake()
    {
        health = PlayerPrefs.GetInt("health");
    }

    public void incHealth(int incNum)
    {
        health += incNum;
        setHealth(health);
    }

    public void setHealth(int health)
    {
        PlayerPrefs.SetInt("health", health);
    }
    public int getHealth()
    {
        return health;
    }
}
