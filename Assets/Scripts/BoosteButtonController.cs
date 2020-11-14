using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class BoosteButtonController : MonoBehaviour
{
    public DataController dataController;
    public Test ad;
    public Text mT1, bT1;
    public Text mT2, bT2;
    public Text mT3, bT3;
    public Text mT4, bT4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mT1.text = "스테로이드 보유량 : " + dataController.getDrug().ToString();
        bT1.text = "스테로이드\n구매\n(광고)";

        mT2.text = "10초간 초당 체력 10배";
        bT2.text = "1개 소모";

        mT3.text = "10초간 터치당 체력 10배";
        bT3.text = "1개 소모";

        mT4.text = "현재 체력 2배";
        bT4.text = "5개 소모";
    }
    public void bB1OnClick()
    {
        ad.AdsShow();
        dataController.incDrug(1);
        //광고 보는건 다른 admob에서 함
    }
    public void bB2OnClick() //초당 10배
    {
        if (dataController.getDrug() >= 1 && dataController.getDrugTimeSecondBool())
        {
            dataController.decDrug(1);
            dataController.drugTimeSecond();
        }
    }
    public void bB3OnClick() //터치 10배
    {
        if (dataController.getDrug() >= 1 && dataController.getDrugTimeTouchBool())
        {
            dataController.decDrug(1);
            dataController.drugTimeTouchFunction();
        }
    }
    public void bB4OnClick() //현재 체력 2배
    {
        if (dataController.getDrug() >= 5)
        {
            dataController.decDrug(5);
            dataController.twoTimesNowHealth();
        }
    }
}
