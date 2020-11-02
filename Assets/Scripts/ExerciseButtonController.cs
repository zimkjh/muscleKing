using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ExerciseButtonController : MonoBehaviour
{
    //public Text mT1, mT2, mT3, mT4, mT5, sT1, sT2, sT3, sT4, sT5;
    public Text mT1, sT1;
    public DataController dataController;
    private int priceExercise1 = 10;
    private int effectExercise1 = 1;
    void Start()
    {
        mT1.text = "팔굽혀펴기";
        sT1.text = "??";
    }
    public void eB1OnClick()
    {
        if (dataController.getHealth("health") > priceExercise1)
        {
            dataController.decHealth("health", priceExercise1);
            dataController.incHealth("healthPerTouch", effectExercise1);
        }
    }
}
