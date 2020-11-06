using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class ClickImage : MonoBehaviour, IPointerClickHandler
{
    public DataController dataController;
    public MainImage mainImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        dataController.incHealth("health", Convert.ToInt32(dataController.getHealth("healthPerTouch") * dataController.getMulHealth() * dataController.getDrugRateTouch()));
        dataController.incAllHealth(Convert.ToInt32(dataController.getHealth("healthPerTouch") * dataController.getMulHealth() * dataController.getDrugRateTouch()));
        dataController.saveInfo();
        mainImage.doTrigger();
    }
}
