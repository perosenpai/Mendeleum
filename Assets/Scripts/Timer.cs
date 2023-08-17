using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float time = 300;
    public TextMeshProUGUI  timerText;

    void Update(){
        if(time > 0){
            time -= Time.deltaTime;
        }else{
            time = 0; 
        }

        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay){
        if(time < 0){
            timeToDisplay = 0;
        }

        float min = Mathf.FloorToInt(timeToDisplay/60);
        float sec = Mathf.FloorToInt(timeToDisplay%60);
        float ms = timeToDisplay%1*1000;

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
