using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewController : MonoBehaviour
{

    public GameObject exerciseScrollView;
    public GameObject proteinScrollView;
    public GameObject gymScrollView;
    public GameObject equipmentScrollView;
    public GameObject boosterScrollView;
    private List<GameObject> scrollViewList = new List<GameObject>();
    void Start()
    {
        scrollViewList.Add(exerciseScrollView);
        scrollViewList.Add(proteinScrollView);
        scrollViewList.Add(gymScrollView);
        scrollViewList.Add(equipmentScrollView);
        scrollViewList.Add(boosterScrollView);
        exerciseScrollView.SetActive(true);
    }
    private void scrollViewUnvisiable()
    {
        foreach (GameObject scroll in scrollViewList)
        {
            scroll.SetActive(false);
        }
    }
    public void exerciseButtonOnclick()
    {
        scrollViewUnvisiable();
        exerciseScrollView.SetActive(true);
    }
    public void proteinButtonOnclick()
    {
        scrollViewUnvisiable();
        proteinScrollView.SetActive(true);
    }
    public void gymButtonOnclick()
    {
        scrollViewUnvisiable();
        gymScrollView.SetActive(true);
    }
    public void equipmentButtonOnclick()
    {
        scrollViewUnvisiable();
        equipmentScrollView.SetActive(true);
    }
    public void boosterButtonOnclick()
    {
        scrollViewUnvisiable();
        boosterScrollView.SetActive(true);
    }
}
