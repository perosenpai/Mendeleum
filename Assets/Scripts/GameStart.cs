using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public GameObject Player;

    private Sprite playerSprite;
    
    void Start(){

        Player.GetComponent<SpriteRenderer>().sprite = playerSprite;
    }

    
}
