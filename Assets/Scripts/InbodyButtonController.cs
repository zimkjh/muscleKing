﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class InbodyButtonController : MonoBehaviour
{
    public GameObject image;
    public void openOnClick()
    {
        
        if(image.activeSelf) {image.SetActive(false);}
        else {image.SetActive(true);}
        
    }
    
    public void closeOnClick()
    {
        image.SetActive(false);
    }
}
