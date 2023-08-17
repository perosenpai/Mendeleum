using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour{

    Transform Doorľ;

    void Update(){
        if(Score.scoreValue >=6){
            Destroy(gameObject);
        }
    }
}
