using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplayer : MonoBehaviour
{
    public Text health;
    public Text healthPerTouch;
    public Text healthPerSecond;
    public DataController dataController;
    private void Update()
    {
        health.text = "현재 체력 : " + dataController.getHealth("health").ToString();
        healthPerTouch.text = dataController.getHealth("healthPerTouch").ToString() + " / 터치";
        healthPerSecond.text = dataController.getHealth("healthPerSecond").ToString() + " / 초";

    }
}
