using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class BoosteButtonController : MonoBehaviour
{
    public DataController dataController;
    public Text mT1, bT1;
    public Text mT2, bT2, rT2;
    public Text mT3, bT3, rT3;
    public Text mT4, bT4, rT4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //텍스트 컨트롤
    }
    public void bB1OnClick()
    {
        dataController.incDrug(1);
        //광고 고
        //약 하나 추가
    }
    public void bB2OnClick()
    {
        if (dataController.getDrug() >= 1)
        {

        }
        //약 있다면
        //약 하나 빼고
        //효과발동
    }
    public void bB3OnClick()
    {
        if (dataController.getDrug() >= 1)
        {

        }
        //약 있다면
        //약 하나 빼고
        //효과발동
    }
    public void bB4OnClick()
    {
        if (dataController.getDrug() >= 5)
        {

        }
        //약 있다면
        //약 5개 빼고
        //효과발동
    }
}
