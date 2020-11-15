using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Newtonsoft.Json;
using System.IO;

public class GymButtonController : MonoBehaviour
{
    public Text[] mainTextList = new Text[5];
    public Text[] priceTextList = new Text[5];
    public Text[] resultTextList = new Text[5];
    public DataController dataController;
    public GymObject[] gymObjectList;
    Dictionary<string, GymObject> gymItemList = new Dictionary<string, GymObject>();

    void Start()
    {
        string data = File.ReadAllText(Application.dataPath + "/Resources/gymObjectList.json");
        gymObjectList = JsonConvert.DeserializeObject<GymObject[]>(data);
        int index = 0;
        foreach (GymObject gymObject in gymObjectList)
        {
            gymItemList[gymObject.name] = gymObject;
            if (PlayerPrefs.HasKey(gymObject.name + "가격")) //샀다는 뜻
            {
                gymItemList[gymObject.name].price = PlayerPrefs.GetInt(gymObject.name + "가격");
                gymItemList[gymObject.name].effect = PlayerPrefs.GetInt(gymObject.name + "효과");
                gymItemList[gymObject.name].setLevel(PlayerPrefs.GetInt(gymObject.name + "레벨"));
            }
            else //안샀음
            {
                gymItemList[gymObject.name].price = gymObject.price;
                gymItemList[gymObject.name].effect = gymObject.effect;
                gymItemList[gymObject.name].setLevel(0);
            }
            if (gymObject.getLevel() == 1)
            {
                mainTextList[index].text = gymObject.name.Split(new string[] { "\n" }, StringSplitOptions.None)[0] + "\n구매 완료";
            }
            else
            {
                mainTextList[index].text = gymObject.name.Split(new string[] { "\n" }, StringSplitOptions.None)[0] + "\n구매 가능";
            }
            priceTextList[index].text = gymItemList[gymObject.name].price.ToString();
            resultTextList[index].text = "+" + ((gymItemList[gymObject.name].effect - 1) * 100).ToString() + "% 체력 / 터치\n+" + ((gymItemList[gymObject.name].effect - 1) * 100).ToString() + "% 체력 / 초";
            index += 1;
        }
    }
    public void buyButtonOnClick(Text gymMainText)
    {
        string name = gymMainText.text.Split(new string[] { "\n" }, StringSplitOptions.None)[0];
        int index = int.Parse(gymMainText.name.ToString()[gymMainText.name.ToString().Length - 1].ToString()) - 1;
        if (gymItemList[name].getLevel() < 1)
        {
            if (buyProcess(name))
            {
                mainTextList[index].text = name + "\n구매 완료";
            }
        }
    }
    bool buyProcess(string name)
    {
        if (dataController.getHealth("health") > gymItemList[name].price)
        {
            dataController.decHealth("health", Convert.ToInt32(gymItemList[name].price));
            dataController.mulHealth(gymItemList[name].effect);

            gymItemList[name].setLevel(gymItemList[name].getLevel() + 1);

            string saveLevel = name + "레벨";
            string savePrice = name + "가격";
            string saveEffect = name + "효과";

            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(gymItemList[name].price));
            PlayerPrefs.SetFloat(saveEffect, gymItemList[name].effect);
            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(gymItemList[name].getLevel()));
            return true;
        }
        return false;
    }
    public void hey(int a, int b)
    {
        Debug.Log("hey");
    }
}
