using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZone : MonoBehaviour
{
    public DataController dataController;
    public MainImage mainImage;

    public void OnClick()
    {
        dataController.incHealth(1);
        mainImage.doTrigger();
    }
}
