using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZone : MonoBehaviour
{
    public DataController dataController;

    public void OnClick()
    {
        dataController.incHealth(1);
    }
}
