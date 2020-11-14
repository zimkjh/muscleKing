using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExerciseObject
{
    public string name;
    public float price;
    public float priceRate;
    public float effect;
    public float effectRate;
    private float level;
    public ExerciseObject(string name, float price, float priceRate, float effect, float effectRate)
    {
        this.name = name;
        this.price = price;
        this.priceRate = priceRate;
        this.effect = effect;
        this.effectRate = effectRate;
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