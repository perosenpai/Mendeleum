using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemItem : MonoBehaviour{

    public string itemName;
    private inventory inv;
    public GameObject itemButton;

    private void Start(){
        inv= GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            for(int i=0; i<inv.slots.Length; i++){
                if(inv.isFull[i]==false){
                    inv.isFull[i]=true;
                    Instantiate(itemButton, inv.slots[i].transform, false);
                    Destroy(gameObject);
                    SoundManager.PlaySound("collect");
                    break;
                }
            }
        }
    }

}
