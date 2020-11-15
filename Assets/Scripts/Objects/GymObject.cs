using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymObject
{
    public string name;
    public float price;
    public float effect;
    private float level;
    public GymObject(string name, float price, float effect)
    {
        this.name = name;
        this.price = price;
        this.effect = effect;
    }
    public void setLevel(float level)
    {
        this.level = level;
    }
    public float getLevel()
    {
        return this.level;
    }
}
