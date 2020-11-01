using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainImage : MonoBehaviour
{
    public void doTrigger()
    {
        this.GetComponent<Animator>().SetTrigger("click");
    }
}
