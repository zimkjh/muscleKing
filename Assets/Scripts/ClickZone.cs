﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZone : MonoBehaviour
{
    public DataStore dataStore;

    public void OnClick()
    {
        dataStore.incHealthCount(1);
    }
}
