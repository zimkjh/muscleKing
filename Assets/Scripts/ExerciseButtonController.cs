using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Newtonsoft.Json;
using System.IO;
public class ExerciseObject
{
    public string name;
    public float price;
    public float priceRate;
    public float effect;
    public float effectRate;
    private float level;
    public ExerciseObject(string name, float price, float priceRate, float effect, float effectRate)
    {
        this.name = name;
        this.price = price;
        this.priceRate = priceRate;
        this.effect = effect;
        this.effectRate = effectRate;
    }
    public void setLevel(float level)
    {
        this.level = level;
    }
    public float getLevel()
    {
        return this.level;
    }
}
public class ExerciseButtonController : MonoBehaviour
{
    // public Text mT1, pT1, rT1;
    // public Text mT2, pT2, rT2;
    // public Text mT3, pT3, rT3;
    // public Text mT4, pT4, rT4;
    // public Text mT5, pT5, rT5;
    private Text[] mainTextList = new Text[5];
    private Text[] priceTextList = new Text[5];
    private Text[] resultTextList = new Text[5];
    // private string[] nameOfExercise = new string[] { "팔굽혀펴기", "윗몸일으키기", "턱걸이", "벤치프레스", "데드리프트" };
    // private float[] priceOfExercise = new float[] { 10f, 100f, 5000f, 20000f, 150000f };
    // private float[] priceRateOfExercise = new float[] { 1.2f, 1.4f, 1.6f, 1.8f, 2f };
    // private float[] effectOfExercise = new float[] { 1f, 5f, 30f, 150f, 500f };
    // private float[] effectRateOfExercise = new float[] { 1f, 5f, 10f, 20f, 50f };
    public DataController dataController;
    // Dictionary<string, float> exerciseItem1 = new Dictionary<string, float>();
    // Dictionary<string, float> exerciseItem2 = new Dictionary<string, float>();
    // Dictionary<string, float> exerciseItem3 = new Dictionary<string, float>();
    // Dictionary<string, float> exerciseItem4 = new Dictionary<string, float>();
    // Dictionary<string, float> exerciseItem5 = new Dictionary<string, float>();
    // Dictionary<string, Dictionary<string, float>> exerciseItemList = new Dictionary<string, Dictionary<string, float>>();
    Dictionary<string, ExerciseObject> exerciseItemList = new Dictionary<string, ExerciseObject>();
    public ExerciseObject[] exerciseObjectList;

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
            // Debug.Log(exerciseItemList[exerciseObject.name].price);
        }
        Debug.Log(exerciseItemList);
        // exerciseItemList["팔굽혀펴기"] = exerciseItem1;
        // exerciseItemList["윗몸일으키기"] = exerciseItem2;
        // exerciseItemList["턱걸이"] = exerciseItem3;
        // exerciseItemList["벤치프레스"] = exerciseItem4;
        // exerciseItemList["데드리프트"] = exerciseItem5;
        // int index = 0;
        // foreach (string name in nameOfExercise)
        // {
        //     if (PlayerPrefs.HasKey(name + "가격")) //샀다는 뜻
        //     {
        //         exerciseItemList[name]["가격"] = PlayerPrefs.GetInt(name + "가격");
        //         exerciseItemList[name]["효과"] = PlayerPrefs.GetInt(name + "효과");
        //         exerciseItemList[name]["레벨"] = PlayerPrefs.GetInt(name + "레벨");
        //     }
        //     else //안샀음
        //     {
        //         exerciseItemList[name]["가격"] = priceOfExercise[index];
        //         exerciseItemList[name]["효과"] = effectOfExercise[index];
        //         exerciseItemList[name]["레벨"] = 0;
        //     }
        //     exerciseItemList[name]["체력증가량"] = effectRateOfExercise[index];
        //     exerciseItemList[name]["가격증가량"] = priceRateOfExercise[index];
        //     index += 1;
        // }
    }
    void Update()
    {
        for (int index = 0; index < exerciseObjectList.Length; index++)
        {
            string nowName = exerciseObjectList[index].name;
            mainTextList[index].text = nowName + "\n" + exerciseItemList[nowName].getLevel() + "lv";
            priceTextList[index].text = exerciseObjectList[index].price.ToString();
            resultTextList[index].text = "+" + exerciseObjectList[index].effect.ToString() + "체력 / 터치";
        }
        // mT1.text = "팔굽혀펴기\n" + exerciseItemList["팔굽혀펴기"]["레벨"] + "lv";
        // mT2.text = "윗몸일으키기\n" + exerciseItemList["윗몸일으키기"]["레벨"] + "lv";
        // mT3.text = "턱걸이\n" + exerciseItemList["턱걸이"]["레벨"] + "lv";
        // mT4.text = "벤치프레스\n" + exerciseItemList["벤치프레스"]["레벨"] + "lv";
        // mT5.text = "데드리프트\n" + exerciseItemList["데드리프트"]["레벨"] + "lv";

        // pT1.text = exerciseItem1["가격"].ToString();
        // rT1.text = "+" + exerciseItem1["효과"].ToString() + "체력 / 터치";

        // pT2.text = exerciseItem2["가격"].ToString();
        // rT2.text = "+" + exerciseItem2["효과"].ToString() + "체력 / 터치";

        // pT3.text = exerciseItem3["가격"].ToString();
        // rT3.text = "+" + exerciseItem3["효과"].ToString() + "체력 / 터치";

        // pT4.text = exerciseItem4["가격"].ToString();
        // rT4.text = "+" + exerciseItem4["효과"].ToString() + "체력 / 터치";

        // pT5.text = exerciseItem5["가격"].ToString();
        // rT5.text = "+" + exerciseItem5["효과"].ToString() + "체력 / 터치";

    }
    public void eB1OnClick()
    {
        buyProcess(exerciseObjectList[0].name);
    }
    public void eB2OnClick()
    {
        buyProcess(exerciseObjectList[1].name);
    }
    public void eB3OnClick()
    {
        buyProcess(exerciseObjectList[2].name);
    }
    public void eB4OnClick()
    {
        buyProcess(exerciseObjectList[3].name);
    }
    public void eB5OnClick()
    {
        buyProcess(exerciseObjectList[4].name);
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

            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(exerciseItemList[name].getLevel()));
            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(exerciseItemList[name].price));
            PlayerPrefs.SetInt(saveEffect, Convert.ToInt32(exerciseItemList[name].effect));
        }
    }
}
