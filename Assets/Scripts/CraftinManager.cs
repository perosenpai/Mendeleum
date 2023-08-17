using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftinManager : MonoBehaviour{

    private ItemItem currentItem;
    public Image customCursor;

    public Slot[] crafintSlots;

    public List<ItemItem> itemList;

    public string[] recipes;
    // List<string> recipesList = new List<string>(recipes);
    public ItemItem[] recipeResults;
    public Slot resultSlot;

    public void Update(){
        if(Input.GetMouseButtonUp(0)){
            if(currentItem != null){
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in crafintSlots){
                    float dist = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f)), slot.transform.position);

                    if(dist<shortestDistance){
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;

                itemList[nearestSlot.index] = currentItem;
                currentItem = null;

                CheckForCreatedRecipes();
            }
        }
    }


    void CheckForCreatedRecipes(){
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach(ItemItem item in itemList){
            if(item !=null){
                currentRecipeString += item.itemName;
            }else{
                currentRecipeString += "null";
            }
        }
            for(int i =0; i<recipes.Length; i++){
                if(recipes[i] == currentRecipeString){
                    resultSlot.gameObject.SetActive(true);
                    Score.scoreValue += 1;
                    resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                    resultSlot.item = recipeResults[i]; 
                }
            }
        
    }

    public void OnClickSlot(Slot slot){
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    public void OnMouseDownItem(ItemItem item){
        if(currentItem ==null){
            currentItem =item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
    }


}
