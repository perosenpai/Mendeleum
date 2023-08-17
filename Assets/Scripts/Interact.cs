using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Interact : MonoBehaviour{
    public GameObject obj;

    void OnTriggerEnter2D(Collider2D collision){
        obj.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision){
            obj.SetActive(false);
    }


}




