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


    public void exerciseButtonOnclick()
    {
        if (exerciseScrollView.activeSelf == true)
        {
            exerciseScrollView.SetActive(false);
        }
        else
        {
            exerciseScrollView.SetActive(true);
        }
    }
    public void proteinButtonOnclick()
    {
        if (proteinScrollView.activeSelf == true)
        {
            proteinScrollView.SetActive(false);
        }
        else
        {
            proteinScrollView.SetActive(true);
        }
    }
    public void gymButtonOnclick()
    {
        if (gymScrollView.activeSelf == true)
        {
            gymScrollView.SetActive(false);
        }
        else
        {
            gymScrollView.SetActive(true);
        }
    }
    public void equipmentButtonOnclick()
    {
        if (equipmentScrollView.activeSelf == true)
        {
            equipmentScrollView.SetActive(false);
        }
        else
        {
            equipmentScrollView.SetActive(true);
        }
    }
    public void boosterButtonOnclick()
    {
        if (boosterScrollView.activeSelf == true)
        {
            boosterScrollView.SetActive(false);
        }
        else
        {
            boosterScrollView.SetActive(true);
        }
    }


}
