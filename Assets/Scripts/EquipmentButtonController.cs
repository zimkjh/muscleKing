using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EquipmentButtonController : MonoBehaviour
{
    //public Text mT1, mT2, mT3, mT4, mT5, sT1, sT2, sT3, sT4, sT5;
    public Text mT1, pT1, rT1;
    public Text mT2, pT2, rT2;
    public Text mT3, pT3, rT3;
    public Text mT4, pT4, rT4;
    public Text mT5, pT5, rT5;
    string[] nameOfEquip = new string[] { "장비_1", "장비_2", "장비_3", "장비_4", "장비_5" };
    float[] restrictOfEquip = new float[] { 200, 300, 400, 450, 500 };
    public DataController dataController;
    Dictionary<string, float> equipItem1 = new Dictionary<string, float>();
    Dictionary<string, float> equipItem2 = new Dictionary<string, float>();
    Dictionary<string, float> equipItem3 = new Dictionary<string, float>();
    Dictionary<string, float> equipItem4 = new Dictionary<string, float>();
    Dictionary<string, float> equipItem5 = new Dictionary<string, float>();
    Dictionary<string, Dictionary<string, float>> equipItemList = new Dictionary<string, Dictionary<string, float>>();

    void Start()
    {
        equipItemList["장비_1"] = equipItem1;
        equipItemList["장비_2"] = equipItem2;
        equipItemList["장비_3"] = equipItem3;
        equipItemList["장비_4"] = equipItem4;
        equipItemList["장비_5"] = equipItem5;
        int index = 0;
        foreach (string name in nameOfEquip)
        {
            if (PlayerPrefs.HasKey(name + "가격")) //샀다는 뜻
            {
                equipItemList[name]["가격"] = PlayerPrefs.GetFloat(name + "가격");
                equipItemList[name]["레벨"] = PlayerPrefs.GetInt(name + "레벨");
            }
            else //안샀음
            {
                equipItemList[name]["가격"] = restrictOfEquip[index];
                equipItemList[name]["레벨"] = 0;
            }
            index += 1;
        }
        if (equipItem1["레벨"] == 1)
        {
            mT1.text = "물병\n구매 완료";
        }
        else
        {
            mT1.text = "물병\n3대 200 이상 구매 가능";
        }
        if (equipItem2["레벨"] == 1)
        {
            mT2.text = "손목 스트랩\n구매 완료";
        }
        else
        {
            mT2.text = "손목 스트랩\n3대 300 이상 구매 가능";
        }
        if (equipItem3["레벨"] == 1)
        {
            mT3.text = "헬스 장갑\n구매 완료";
        }
        else
        {
            mT3.text = "헬스 장갑\n3대 400 이상 구매 가능";
        }
        if (equipItem4["레벨"] == 1)
        {
            mT4.text = "헬스 벨트\n구매 완료";
        }
        else
        {
            mT4.text = "헬스 벨트\n3대 450 이상 구매 가능";
        }
        if (equipItem5["레벨"] == 1)
        {
            mT5.text = "언더아머\n구매 완료";
        }
        else
        {
            mT5.text = "언더아머\n3대 500 이상 구매 가능";
        }

        // pT1.text = equipItem1["가격"].ToString();
        // rT1.text = "+" + ((equipItem1["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((equipItem1["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        // pT2.text = equipItem2["가격"].ToString();
        // rT2.text = "+" + ((equipItem2["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((equipItem2["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        // pT3.text = equipItem3["가격"].ToString();
        // rT3.text = "+" + ((equipItem3["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((equipItem3["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        // pT4.text = equipItem4["가격"].ToString();
        // rT4.text = "+" + ((equipItem4["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((equipItem4["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        // pT5.text = equipItem5["가격"].ToString();
        // rT5.text = "+" + ((equipItem5["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((equipItem5["효과"] - 1) * 100).ToString() + "% 체력 / 초";

    }
    void Update()
    {


    }
    public void eqB1OnClick()
    {
        if (equipItem1["레벨"] < 1)
        {
            buyProcess("장비_1");
            mT1.text = "물병\n구매 완료";
        }
    }
    public void eqB2OnClick()
    {
        if (equipItem2["레벨"] < 1)
        {
            buyProcess("장비_2");
            mT2.text = "손목 스트랩\n구매 완료";
        }
    }
    public void eqB3OnClick()
    {
        if (equipItem3["레벨"] < 1)
        {
            buyProcess("장비_3");
            mT3.text = "헬스 장갑\n구매 완료";
        }
    }
    public void eqB4OnClick()
    {
        if (equipItem4["레벨"] < 1)
        {
            buyProcess("장비_4");
            mT4.text = "헬스 벨트\n구매 완료";
        }
    }
    public void eqB5OnClick()
    {
        if (equipItem5["레벨"] < 1)
        {
            buyProcess("장비_5");
            mT5.text = "언더아머\n구매 완료";

        }
    }

    void buyProcess(string name)
    {
        if (dataController.getAllHealth() > equipItemList[name]["가격"])
        {
            equipItemList[name]["레벨"] += 1;

            string saveLevel = name + "레벨";

            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(equipItemList[name]["레벨"]));
        }
    }
}
