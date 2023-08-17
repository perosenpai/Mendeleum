using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAnimation : MonoBehaviour{
   
    private Animator anim;
    public GameObject selectedGender;
    public GameObject player;
    public GameObject playerGender;
    private AudioSource walk;
    // TextMeshProUGUI uiText = GameObject.Find("Girl_pose0").GetComponent<TextMeshProUGUI>();
    public List<Sprite> skins = new List<Sprite>();

    private Sprite playerSprite;
    public string[] staticDirections = {"Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE"};
    public string[] staticDirectionsW = {"StaticW N", "StaticW NW", "StaticW W", "StaticW SW", "StaticW S", "StaticW SE", "StaticW E", "StaticW NE"};
    public string[] runDirections = {"Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE"};
    public string[] runDirectionsW = {"RunW N", "RunW NW", "RunW W", "RunW SW", "RunW S", "RunW SE", "RunW E", "RunW NE"};

    int lastDirection;
    

    private void Awake(){
        anim = GetComponent<Animator>();
        walk = GetComponent<AudioSource>();
    }

    public void SetDirection(Vector2 _direction){
        string[] directionArray = null;

        if(_direction.magnitude < 0.01){
            directionArray = staticDirections;
        // }else if(skins.Contains("Boy_pose0")){
        //     directionArray = staticDirectionsW;
        }else{
            directionArray = runDirections;
            lastDirection = DirectionToIndex(_direction);
        }

        anim.Play(directionArray[lastDirection]);
    }


    private int DirectionToIndex(Vector2 _direction){
        
        Vector2 norDir = _direction.normalized;
        float step = 360/8;
        float offset = step/2;

        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;
        if(angle < 0){
            angle += 360;
        }

        float stepCount = angle/step;
        return Mathf.FloorToInt(stepCount);
    }

    private void Walk(){
        walk.Play();
    }
}
