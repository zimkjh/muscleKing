using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ExerciseButtonController : MonoBehaviour
{
    //public Text mT1, mT2, mT3, mT4, mT5, sT1, sT2, sT3, sT4, sT5;
    public Text mT1, sT1, pT1, rT1;
    public Text mT2, sT2, pT2, rT2;
    public Text mT3, sT3, pT3, rT3;
    public Text mT4, sT4, pT4, rT4;
    public Text mT5, sT5, pT5, rT5;

    public DataController dataController;
    Dictionary<string, double> exerciseItem1 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem2 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem3 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem4 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem5 = new Dictionary<string, double>();
    Dictionary<string, Dictionary<string, double>> exerciseItemList = new Dictionary<string, Dictionary<string, double>>();
    void Start()
    {
        mT1.text = "팔굽혀펴기";
        sT1.text = "운동의 기초";
        exerciseItem1["가격"] = 10;
        exerciseItem1["효과"] = 1;
        exerciseItem1["레벨"] = 0;
        exerciseItem1["체력증가량"] = 1;
        exerciseItem1["가격증가량"] = 1.2;

        mT2.text = "윗몸일으키기";
        sT2.text = "식스팩을 만들자";
        exerciseItem2["가격"] = 100;
        exerciseItem2["효과"] = 5;
        exerciseItem2["레벨"] = 0;
        exerciseItem2["체력증가량"] = 5;
        exerciseItem2["가격증가량"] = 1.4;

        mT3.text = "턱걸이";
        sT3.text = "맨몸운동의 끝판왕";
        exerciseItem3["가격"] = 5000;
        exerciseItem3["효과"] = 30;
        exerciseItem3["레벨"] = 0;
        exerciseItem3["체력증가량"] = 10;
        exerciseItem3["가격증가량"] = 1.6;

        mT4.text = "벤치프레스";
        sT4.text = "탄탄한 가슴";
        exerciseItem4["가격"] = 20000;
        exerciseItem4["효과"] = 150;
        exerciseItem4["레벨"] = 0;
        exerciseItem4["체력증가량"] = 20;
        exerciseItem4["가격증가량"] = 1.8;

        mT5.text = "데드리프트";
        sT5.text = "탄탄한 가슴";
        exerciseItem5["가격"] = 150000;
        exerciseItem5["효과"] = 500;
        exerciseItem5["레벨"] = 0;
        exerciseItem5["체력증가량"] = 50;
        exerciseItem5["가격증가량"] = 2;


        exerciseItemList["팔굽혀펴기"] = exerciseItem1;
        exerciseItemList["윗몸일으키기"] = exerciseItem2;
        exerciseItemList["턱걸이"] = exerciseItem3;
        exerciseItemList["벤치프레스"] = exerciseItem4;
        exerciseItemList["데드리프트"] = exerciseItem5;


    }
    void Update()
    {
        pT1.text = exerciseItem1["가격"].ToString();
        rT1.text = exerciseItem1["효과"].ToString() + "체력 / 터치";

        pT2.text = exerciseItem2["가격"].ToString();
        rT2.text = exerciseItem2["효과"].ToString() + "체력 / 터치";

        pT3.text = exerciseItem3["가격"].ToString();
        rT3.text = exerciseItem3["효과"].ToString() + "체력 / 터치";

        pT4.text = exerciseItem4["가격"].ToString();
        rT4.text = exerciseItem4["효과"].ToString() + "체력 / 터치";

        pT5.text = exerciseItem5["가격"].ToString();
        rT5.text = exerciseItem5["효과"].ToString() + "체력 / 터치";

    }
    public void eB1OnClick()
    {
        buyProcess("팔굽혀펴기");
    }
    public void eB2OnClick()
    {
        buyProcess("윗몸일으키기");
    }
    public void eB3OnClick()
    {
        buyProcess("턱걸이");
    }
    public void eB4OnClick()
    {
        buyProcess("벤치프레스");
    }
    public void eB5OnClick()
    {
        buyProcess("데드리프트");
    }


    void buyProcess(string name)
    {
        if (dataController.getHealth("health") > exerciseItemList[name]["가격"])
        {
            dataController.decHealth("health", Convert.ToInt32(exerciseItemList[name]["가격"]));
            dataController.incHealth("healthPerTouch", Convert.ToInt32(exerciseItemList[name]["효과"]));

            exerciseItemList[name]["레벨"] += 1;
            exerciseItemList[name]["가격"] = Convert.ToInt32(exerciseItemList[name]["가격"] * exerciseItemList[name]["가격증가량"]);
            exerciseItemList[name]["효과"] += exerciseItemList[name]["체력증가량"];
        }
    }

}
