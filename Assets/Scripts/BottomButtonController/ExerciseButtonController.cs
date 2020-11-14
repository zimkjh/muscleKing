using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Newtonsoft.Json;
using System.IO;
public class ExerciseButtonController : MonoBehaviour
{
    public Text[] mainTextList = new Text[5];
    public Text[] priceTextList = new Text[5];
    public Text[] resultTextList = new Text[5];
    public DataController dataController;
    public ExerciseObject[] exerciseObjectList;
    Dictionary<string, ExerciseObject> exerciseItemList = new Dictionary<string, ExerciseObject>();

    void Start()
    {
        string data = File.ReadAllText(Application.dataPath + "/Resources/exerciseObjectList.json");
        exerciseObjectList = JsonConvert.DeserializeObject<ExerciseObject[]>(data);
        foreach (ExerciseObject exerciseObject in exerciseObjectList)
        {
            exerciseItemList[exerciseObject.name] = exerciseObject;
            if (PlayerPrefs.HasKey(exerciseObject.name + "가격")) //샀다는 뜻
            {
                exerciseItemList[exerciseObject.name].price = PlayerPrefs.GetInt(exerciseObject.name + "가격");
                exerciseItemList[exerciseObject.name].effect = PlayerPrefs.GetInt(exerciseObject.name + "효과");
                exerciseItemList[exerciseObject.name].setLevel(PlayerPrefs.GetInt(exerciseObject.name + "레벨"));
            }
            else //안샀음
            {
                exerciseItemList[exerciseObject.name].price = exerciseObject.price;
                exerciseItemList[exerciseObject.name].effect = exerciseObject.effect;
                exerciseItemList[exerciseObject.name].setLevel(0);
            }
            exerciseItemList[exerciseObject.name].priceRate = exerciseObject.priceRate;
            exerciseItemList[exerciseObject.name].effectRate = exerciseObject.effectRate;
        }
    }
    void Update()
    {
        for (int index = 0; index < exerciseObjectList.Length; index++)
        {
            string nowName = exerciseObjectList[index].name;
            mainTextList[index].text = nowName + "\n" + exerciseItemList[nowName].getLevel().ToString() + "lv";
            priceTextList[index].text = exerciseObjectList[index].price.ToString();
            resultTextList[index].text = "+" + exerciseObjectList[index].effect.ToString() + "체력 / 터치";
        }
    }
    public void buyButtonOnClick(Text exerciseMainText)
    {
        buyProcess(exerciseMainText.text.Split(new string[] { "\n" }, StringSplitOptions.None)[0]);
    }
    void buyProcess(string name)
    {
        if (dataController.getHealth("health") > exerciseItemList[name].price)
        {
            dataController.decHealth("health", Convert.ToInt32(exerciseItemList[name].price));
            dataController.incHealth("healthPerTouch", Convert.ToInt32(exerciseItemList[name].effect));

            exerciseItemList[name].setLevel(exerciseItemList[name].getLevel() + 1);
            exerciseItemList[name].price = Convert.ToInt32(exerciseItemList[name].price * exerciseItemList[name].priceRate);
            exerciseItemList[name].effect += exerciseItemList[name].effectRate;

            string saveLevel = name + "레벨";
            string savePrice = name + "가격";
            string saveEffect = name + "효과";

            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(exerciseItemList[name].price));
            PlayerPrefs.SetInt(saveEffect, Convert.ToInt32(exerciseItemList[name].effect));
            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(exerciseItemList[name].getLevel()));
        }
    }
}
