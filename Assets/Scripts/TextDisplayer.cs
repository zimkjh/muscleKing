using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TextDisplayer : MonoBehaviour
{
    public Text health;
    public Text healthPerTouch;
    public Text healthPerSecond;
    public Text allHealth;
    public Text muscleVal;
    public Text threeWeight;
    public Text weight;
    public DataController dataController;
    public NumberFormatting numberFormatting;
    private void Update()
    {
        health.text = "현재 체력 : " + numberFormatting.formatting(dataController.getHealth("health"));
        healthPerTouch.text = numberFormatting.formatting(Convert.ToInt32(dataController.getHealth("healthPerTouch") * dataController.getMulHealth() * dataController.getDrugRateTouch())) + " / 터치";
        healthPerSecond.text = numberFormatting.formatting(Convert.ToInt32(dataController.getHealth("healthPerSecond") * dataController.getMulHealth() * dataController.getDrugRate())) + " / 초";
        allHealth.text = "총 체력 : " + numberFormatting.formatting(dataController.getAllHealth());
        muscleVal.text = "근육량 : " + Math.Round(dataController.getMuscleVal(), 2).ToString() + "kg";
        threeWeight.text = "3대 : " + Math.Round(dataController.getThreeWeight(), 2).ToString() + "kg";
        weight.text = "몸무게 : " + Math.Round(dataController.getWeight(), 2).ToString() + "kg";
    }
}
