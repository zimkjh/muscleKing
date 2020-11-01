using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickImage : MonoBehaviour, IPointerClickHandler
{
    public DataController dataController;
    public void OnPointerClick(PointerEventData eventData)
    {
        dataController.incHealth(1);
    }
}
