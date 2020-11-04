﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ExerciseButtonController : MonoBehaviour
{
    //public Text mT1, mT2, mT3, mT4, mT5, sT1, sT2, sT3, sT4, sT5;
    public Text mT1, pT1, rT1;
    public Text mT2, pT2, rT2;
    public Text mT3, pT3, rT3;
    public Text mT4, pT4, rT4;
    public Text mT5, pT5, rT5;
    string[] nameOfExercise = new string[] { "팔굽혀펴기", "윗몸일으키기", "턱걸이", "벤치프레스", "데드리프트" };
    double[] priceOfExercise = new double[] { 10, 100, 5000, 20000, 150000 };
    double[] effectOfExercise = new double[] { 1, 5, 30, 150, 500 };
    double[] effectRateOfExercise = new double[] { 1, 5, 10, 20, 50 };
    double[] priceRateOfExercise = new double[] { 1.2, 1.4, 1.6, 1.8, 2 };
    public DataController dataController;
    Dictionary<string, double> exerciseItem1 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem2 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem3 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem4 = new Dictionary<string, double>();
    Dictionary<string, double> exerciseItem5 = new Dictionary<string, double>();
    Dictionary<string, Dictionary<string, double>> exerciseItemList = new Dictionary<string, Dictionary<string, double>>();

    void Start()
    {
        exerciseItemList["팔굽혀펴기"] = exerciseItem1;
        exerciseItemList["윗몸일으키기"] = exerciseItem2;
        exerciseItemList["턱걸이"] = exerciseItem3;
        exerciseItemList["벤치프레스"] = exerciseItem4;
        exerciseItemList["데드리프트"] = exerciseItem5;
        int index = 0;
        foreach (string name in nameOfExercise)
        {
            if (PlayerPrefs.HasKey(name + "가격")) //샀다는 뜻
            {
                exerciseItemList[name]["가격"] = PlayerPrefs.GetInt(name + "가격");
                exerciseItemList[name]["효과"] = PlayerPrefs.GetInt(name + "효과");
                exerciseItemList[name]["레벨"] = PlayerPrefs.GetInt(name + "레벨");
            }
            else //안샀음
            {
                exerciseItemList[name]["가격"] = priceOfExercise[index];
                exerciseItemList[name]["효과"] = effectOfExercise[index];
                exerciseItemList[name]["레벨"] = 0;
            }
            exerciseItemList[name]["체력증가량"] = effectRateOfExercise[index];
            exerciseItemList[name]["가격증가량"] = priceRateOfExercise[index];
            index += 1;
        }

    }
    void Update()
    {
        mT1.text = "팔굽혀펴기\n" + exerciseItemList["팔굽혀펴기"]["레벨"] + "lv";
        mT2.text = "윗몸일으키기\n" + exerciseItemList["윗몸일으키기"]["레벨"] + "lv";
        mT3.text = "턱걸이\n" + exerciseItemList["턱걸이"]["레벨"] + "lv";
        mT4.text = "벤치프레스\n" + exerciseItemList["벤치프레스"]["레벨"] + "lv";
        mT5.text = "데드리프트\n" + exerciseItemList["데드리프트"]["레벨"] + "lv";

        pT1.text = exerciseItem1["가격"].ToString();
        rT1.text = "+" + exerciseItem1["효과"].ToString() + "체력 / 터치";

        pT2.text = exerciseItem2["가격"].ToString();
        rT2.text = "+" + exerciseItem2["효과"].ToString() + "체력 / 터치";

        pT3.text = exerciseItem3["가격"].ToString();
        rT3.text = "+" + exerciseItem3["효과"].ToString() + "체력 / 터치";

        pT4.text = exerciseItem4["가격"].ToString();
        rT4.text = "+" + exerciseItem4["효과"].ToString() + "체력 / 터치";

        pT5.text = exerciseItem5["가격"].ToString();
        rT5.text = "+" + exerciseItem5["효과"].ToString() + "체력 / 터치";

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

            string saveLevel = name + "레벨";
            string savePrice = name + "가격";
            string saveEffect = name + "효과";

            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(exerciseItemList[name]["레벨"]));
            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(exerciseItemList[name]["가격"]));
            PlayerPrefs.SetInt(saveEffect, Convert.ToInt32(exerciseItemList[name]["효과"]));
        }
    }

}


//PlayerPrefs.SetInt(이름, 저장할 인트값);
//저장을 언제 해야 하는가 -> 물건을 살 때 그치 살때가 최신이니까 살때만 저장하면됨.
//저장은 살때 불러오는건 킬때
//저장할때 이름+레벨, 이름+가격, 이름+효과.. 이렇게 해야할듯
//그럼 팔굽혀펴기레벨, 팔굽혀펴기가격, 팔굽혀펴기효과 이런식..
//가격 효과 레벨 3가지 저장하면 됨.