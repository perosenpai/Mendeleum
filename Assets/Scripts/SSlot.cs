using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSlot : MonoBehaviour{

    private inventory inv;
    public int i;

    private void Start(){
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void Update(){
        if(transform.childCount <=0){
            inv.isFull[i] = false;
        }
    }

    public void DropItem(){
        Destroy(gameObject);
        SoundManager.PlaySound("drop");
    }
}
