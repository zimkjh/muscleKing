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
    string[] nameOfGym = new string[] { "헬스장_1", "헬스장_2", "헬스장_3", "헬스장_4", "헬스장_5" };
    float[] priceOfGym = new float[] { 1000000, 10000000, 50000000, 200000000, 1000000000 }; //1백만, 1천만, 5천만, 2억, 10억
    float[] effectOfGym = new float[] { 1.1f, 1.2f, 1.3f, 1.4f, 1.5f };
    public DataController dataController;
    Dictionary<string, float> gymItem1 = new Dictionary<string, float>();
    Dictionary<string, float> gymItem2 = new Dictionary<string, float>();
    Dictionary<string, float> gymItem3 = new Dictionary<string, float>();
    Dictionary<string, float> gymItem4 = new Dictionary<string, float>();
    Dictionary<string, float> gymItem5 = new Dictionary<string, float>();
    Dictionary<string, Dictionary<string, float>> gymItemList = new Dictionary<string, Dictionary<string, float>>();

    void Start()
    {
        gymItemList["헬스장_1"] = gymItem1;
        gymItemList["헬스장_2"] = gymItem2;
        gymItemList["헬스장_3"] = gymItem3;
        gymItemList["헬스장_4"] = gymItem4;
        gymItemList["헬스장_5"] = gymItem5;
        int index = 0;
        foreach (string name in nameOfGym)
        {
            if (PlayerPrefs.HasKey(name + "가격")) //샀다는 뜻
            {
                gymItemList[name]["가격"] = PlayerPrefs.GetInt(name + "가격");
                gymItemList[name]["효과"] = PlayerPrefs.GetFloat(name + "효과");
                gymItemList[name]["레벨"] = PlayerPrefs.GetInt(name + "레벨");
            }
            else //안샀음
            {
                gymItemList[name]["가격"] = priceOfGym[index];
                gymItemList[name]["효과"] = effectOfGym[index];
                gymItemList[name]["레벨"] = 0;
            }
            index += 1;
        }
        if (gymItem1["레벨"] == 1)
        {
            mT1.text = "야외 헬스장\n구매 완료";
        }
        else
        {
            mT1.text = "야외 헬스장\n구매 가능";
        }
        if (gymItem2["레벨"] == 1)
        {
            mT2.text = "동네 헬스장\n구매 완료";
        }
        else
        {
            mT2.text = "동네 헬스장\n구매 가능";
        }
        if (gymItem3["레벨"] == 1)
        {
            mT3.text = "시내 헬스장\n구매 완료";
        }
        else
        {
            mT3.text = "시내 헬스장\n구매 가능";
        }
        if (gymItem4["레벨"] == 1)
        {
            mT4.text = "단체 PT\n구매 완료";
        }
        else
        {
            mT4.text = "단체 PT\n구매 가능";
        }
        if (gymItem5["레벨"] == 1)
        {
            mT5.text = "개인 PT\n구매 완료";
        }
        else
        {
            mT5.text = "개인 PT\n구매 가능";
        }

        pT1.text = gymItem1["가격"].ToString();
        rT1.text = "+" + ((gymItem1["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((gymItem1["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        pT2.text = gymItem2["가격"].ToString();
        rT2.text = "+" + ((gymItem2["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((gymItem2["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        pT3.text = gymItem3["가격"].ToString();
        rT3.text = "+" + ((gymItem3["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((gymItem3["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        pT4.text = gymItem4["가격"].ToString();
        rT4.text = "+" + ((gymItem4["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((gymItem4["효과"] - 1) * 100).ToString() + "% 체력 / 초";

        pT5.text = gymItem5["가격"].ToString();
        rT5.text = "+" + ((gymItem5["효과"] - 1) * 100).ToString() + "% 체력 / 터치\n" + "+" + ((gymItem5["효과"] - 1) * 100).ToString() + "% 체력 / 초";

    }
    void Update()
    {


    }
    public void gB1OnClick()
    {
        if (gymItem1["레벨"] < 1)
        {
            buyProcess("헬스장_1");
            mT1.text = "야외 헬스장\n구매 완료";
        }
    }
    public void gB2OnClick()
    {
        if (gymItem2["레벨"] < 1)
        {
            buyProcess("헬스장_2");
            mT2.text = "동네 헬스장\n구매 완료";
        }
    }
    public void gB3OnClick()
    {
        if (gymItem3["레벨"] < 1)
        {
            buyProcess("헬스장_3");
            mT3.text = "시내 헬스장\n구매 완료";
        }
    }
    public void gB4OnClick()
    {
        if (gymItem4["레벨"] < 1)
        {
            buyProcess("헬스장_4");
            mT4.text = "단체 PT\n구매 완료";
        }
    }
    public void gB5OnClick()
    {
        if (gymItem5["레벨"] < 1)
        {
            buyProcess("헬스장_5");
            mT5.text = "개인 PT\n구매 완료";

        }
    }

    void buyProcess(string name)
    {
        if (dataController.getHealth("health") > gymItemList[name]["가격"])
        {
            dataController.decHealth("health", Convert.ToInt32(gymItemList[name]["가격"]));
            dataController.mulHealth(gymItemList[name]["효과"]);

            gymItemList[name]["레벨"] += 1;

            string saveLevel = name + "레벨";
            string savePrice = name + "가격";
            string saveEffect = name + "효과";

            PlayerPrefs.SetInt(saveLevel, Convert.ToInt32(gymItemList[name]["레벨"]));
            PlayerPrefs.SetInt(savePrice, Convert.ToInt32(gymItemList[name]["가격"]));
            PlayerPrefs.SetFloat(saveEffect, gymItemList[name]["효과"]);
        }
    }
}
