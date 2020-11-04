using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class proteinButtonController : MonoBehaviour
{
    //public Text mT1, mT2, mT3, mT4, mT5, sT1, sT2, sT3, sT4, sT5;
    public Text mT1, pT1, rT1;
    public Text mT2, pT2, rT2;
    public Text mT3, pT3, rT3;
    public Text mT4, pT4, rT4;
    public Text mT5, pT5, rT5;
    string[] nameOfProtein = new string[] { "계란", "두유", "닭가슴살", "WPC보충제", "WPIH보충제" };
    double[] priceOfProtein = new double[] { 20, 200, 10000, 40000, 300000 };
    double[] effectOfProtein = new double[] { 5, 25, 150, 750, 2500 };
    double[] effectRateOfProtein = new double[] { 5, 25, 50, 100, 250 };
    double[] priceRateOfProtein = new double[] { 1.2, 1.4, 1.6, 1.8, 2 };
    public DataController dataController;
    Dictionary<string, double> proteinItem1 = new Dictionary<string, double>();
    Dictionary<string, double> proteinItem2 = new Dictionary<string, double>();
    Dictionary<string, double> proteinItem3 = new Dictionary<string, double>();
    Dictionary<string, double> proteinItem4 = new Dictionary<string, double>();
    Dictionary<string, double> proteinItem5 = new Dictionary<string, double>();
    Dictionary<string, Dictionary<string, double>> proteinItemList = new Dictionary<string, Dictionary<string, double>>();

    void Start()
    {
        proteinItemList["계란"] = proteinItem1;
        proteinItemList["두유"] = proteinItem2;
        proteinItemList["닭가슴살"] = proteinItem3;
        proteinItemList["WPC보충제"] = proteinItem4;
        proteinItemList["WPIH보충제"] = proteinItem5;
        int index = 0;
        foreach (string name in nameOfProtein)
        {
            if (PlayerPrefs.HasKey(name + "가격")) //샀다는 뜻
            {
                proteinItemList[name]["가격"] = PlayerPrefs.GetInt(name + "가격");
                proteinItemList[name]["효과"] = PlayerPrefs.GetInt(name + "효과");
                proteinItemList[name]["레벨"] = PlayerPrefs.GetInt(name + "레벨");
            }
            else //안샀음
            {
                proteinItemList[name]["가격"] = priceOfProtein[index];
                proteinItemList[name]["효과"] = effectOfProtein[index];
                proteinItemList[name]["레벨"] = 0;
            }
            proteinItemList[name]["체력증가량"] = effectRateOfProtein[index];
            proteinItemList[name]["가격증가량"] = priceRateOfProtein[index];
            index += 1;
        }

    }
    void Update()
    {
        mT1.text = "계란\n" + proteinItemList["계란"]["레벨"] + "lv";
        mT2.text = "두유\n" + proteinItemList["두유"]["레벨"] + "lv";
        mT3.text = "닭가슴살\n" + proteinItemList["닭가슴살"]["레벨"] + "lv";
        mT4.text = "WPC보충제\n" + proteinItemList["WPC보충제"]["레벨"] + "lv";
        mT5.text = "WPIH보충제 + 영양제\n" + proteinItemList["WPIH보충제"]["레벨"] + "lv";

        pT1.text = proteinItem1["가격"].ToString();
        rT1.text = "+" + proteinItem1["효과"].ToString() + "체력 / 초";

        pT2.text = proteinItem2["가격"].ToString();
        rT2.text = "+" + proteinItem2["효과"].ToString() + "체력 / 초";

        pT3.text = proteinItem3["가격"].ToString();
        rT3.text = "+" + proteinItem3["효과"].ToString() + "체력 / 초";

        pT4.text = proteinItem4["가격"].ToString();
        rT4.text = "+" + proteinItem4["효과"].ToString() + "체력 / 초";

        pT5.text = proteinItem5["가격"].ToString();
        rT5.text = "+" + proteinItem5["효과"].ToString() + "체력 / 초";

    }
    public void pB1OnClick()
    {
        buyProcess("계란");
    }
    public void pB2OnClick()
    {
        buyProcess("두유");
    }
    public void pB3OnClick()
    {
        buyProcess("닭가슴살");
    }
    public void pB4OnClick()
    {
        buyProcess("WPC보충제");
    }
    public void pB5OnClick()
    {
        buyProcess("WPIH보충제");
    }

    void buyProcess(string name)
    {
        if (dataController.getHealth("health") > proteinItemList[name]["가격"])
        {
            dataController.decHealth("health", Convert.ToInt32(proteinItemList[name]["가격"]));
            dataController.incHealth("healthPerSecond", Convert.ToInt32(proteinItemList[name]["효과"]));

            proteinItemList[name]["레벨"] += 1;
            proteinItemList[name]["가격"] = Convert.ToInt32(proteinItemList[name]["가격"] * proteinItemList[name]["가격증가량"]);
            proteinItemList[name]["효과"] += proteinItemList[name]["체력증가량"];

            string saveLevel = name + "레벨";
            string savePrice = name + "가격";
            string saveEffect = name + "효과";

            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(proteinItemList[name]["레벨"]));
            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(proteinItemList[name]["가격"]));
            PlayerPrefs.SetInt(saveEffect, Convert.ToInt32(proteinItemList[name]["효과"]));
        }
    }
}