using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class animUpdate : MonoBehaviour{

    public float x, y;
    public int i;
    void Update(){
        if(Score.scoreValue >= i){
            gameObject.transform.position = new Vector2(x, y);
        }
    }
}
