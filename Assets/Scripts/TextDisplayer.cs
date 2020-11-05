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
    private void Update()
    {
        health.text = "현재 체력 : " + dataController.getHealth("health").ToString();
        healthPerTouch.text = Convert.ToInt32(dataController.getHealth("healthPerTouch") * dataController.getMulHealth()).ToString() + " / 터치";
        healthPerSecond.text = Convert.ToInt32(dataController.getHealth("healthPerSecond") * dataController.getMulHealth()).ToString() + " / 초";
        allHealth.text = "총 체력 : " + dataController.getAllHealth().ToString();
        muscleVal.text = "근육량 : " + dataController.getMuscleVal().ToString();
        threeWeight.text = "3대 : " + dataController.getThreeWeight().ToString();
        weight.text = "몸무게 : " + dataController.getWeight().ToString();
    }
}
