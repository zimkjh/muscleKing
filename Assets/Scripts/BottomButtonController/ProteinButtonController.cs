using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Newtonsoft.Json;
using System.IO;

public class ProteinButtonController : MonoBehaviour
{
    public Text[] mainTextList = new Text[5];
    public Text[] priceTextList = new Text[5];
    public Text[] resultTextList = new Text[5];
    public DataController dataController;
    public ProteinObject[] proteinObjectList;
    Dictionary<string, ProteinObject> proteinItemList = new Dictionary<string, ProteinObject>();

    void Start()
    {
        string data = File.ReadAllText(Application.dataPath + "/Resources/proteinObjectList.json");
        proteinObjectList = JsonConvert.DeserializeObject<ProteinObject[]>(data);
        foreach (ProteinObject proteinObject in proteinObjectList)
        {
            proteinItemList[proteinObject.name] = proteinObject;
            if (PlayerPrefs.HasKey(proteinObject.name + "가격")) //샀다는 뜻
            {
                proteinItemList[proteinObject.name].price = PlayerPrefs.GetInt(proteinObject.name + "가격");
                proteinItemList[proteinObject.name].effect = PlayerPrefs.GetInt(proteinObject.name + "효과");
                proteinItemList[proteinObject.name].setLevel(PlayerPrefs.GetInt(proteinObject.name + "레벨"));
            }
            else //안샀음
            {
                proteinItemList[proteinObject.name].price = proteinObject.price;
                proteinItemList[proteinObject.name].effect = proteinObject.effect;
                proteinItemList[proteinObject.name].setLevel(0);
            }
            proteinItemList[proteinObject.name].priceRate = proteinObject.priceRate;
            proteinItemList[proteinObject.name].effectRate = proteinObject.effectRate;
        }
    }
    void Update()
    {
        for (int index = 0; index < proteinObjectList.Length; index++)
        {
            string nowName = proteinObjectList[index].name;
            mainTextList[index].text = nowName + "\n" + proteinItemList[nowName].getLevel().ToString() + "lv";
            priceTextList[index].text = proteinObjectList[index].price.ToString();
            resultTextList[index].text = "+" + proteinObjectList[index].effect.ToString() + "체력 / 초";
        }
    }
    public void buyButtonOnClick(Text proteinMainText)
    {
        buyProcess(proteinMainText.text.Split(new string[] { "\n" }, StringSplitOptions.None)[0]);
    }
    void buyProcess(string name)
    {
        if (dataController.getHealth("health") > proteinItemList[name].price)
        {
            dataController.decHealth("health", Convert.ToInt32(proteinItemList[name].price));
            dataController.incHealth("healthPerTouch", Convert.ToInt32(proteinItemList[name].effect));

            proteinItemList[name].setLevel(proteinItemList[name].getLevel() + 1);
            proteinItemList[name].price = Convert.ToInt32(proteinItemList[name].price * proteinItemList[name].priceRate);
            proteinItemList[name].effect += proteinItemList[name].effectRate;

            string saveLevel = name + "레벨";
            string savePrice = name + "가격";
            string saveEffect = name + "효과";

            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(proteinItemList[name].price));
            PlayerPrefs.SetInt(saveEffect, Convert.ToInt32(proteinItemList[name].effect));
            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(proteinItemList[name].getLevel()));
        }
    }
}
