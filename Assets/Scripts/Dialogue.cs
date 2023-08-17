using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float speed;

    private int textIndex;
    void Start(){
        SoundManager.PlaySound("list");
        textComp.text = string.Empty;
        StartDialogue();
        
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            NextLine();
            // SoundManager.PlaySound("djed");
        }
        else{
            StopAllCoroutines();
            textComp.text = lines[textIndex];
        }
    }

    void StartDialogue(){
        textIndex = 0;
        
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[textIndex].ToCharArray()){
            textComp.text += c;
            yield return new WaitForSeconds(speed);
        }

    }

    void NextLine(){
        if(textIndex < lines.Length -1){
            textIndex++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            SceneManager.LoadScene("LabScene");
        }
    }
}
