using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
    private int muscleCount = 0;

    void Awake() {
        muscleCount = PlayerPrefs.GetInt("muscleCount");
    }

    public void incMuscleCount(int incNum){
        muscleCount += incNum;
        setMuscleCount(muscleCount);
        
    }

    public void setMuscleCount(int muscleCount){
        PlayerPrefs.SetInt("muscleCount", muscleCount);
    }
    public int getMuscleCount(){
        return muscleCount;
    }
    

}
