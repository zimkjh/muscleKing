using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplayer : MonoBehaviour
{
    public Text health;
    public DataController dataController;
    private void Update()
    {
        health.text = "현재 체력 : " + dataController.getHealth("health").ToString();
    }
}
