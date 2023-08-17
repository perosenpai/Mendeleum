using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]

public class Boundary {
    public float Xmin, Xmax, Ymin, Ymax;
}

public class PlayerMovement : MonoBehaviour{
    public static PlayerMovement Instance { get; private set; }
    private Rigidbody2D playerRigidbody; 
    public float playerMovementSpeed;
    public Boundary boundary;
    
    void Start(){
        playerRigidbody = GetComponent<Rigidbody2D>();        
    }

    public void Awake(){
        Instance = this;
    }

    void FixedUpdate(){
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        float horizontalMovement = movementX * playerMovementSpeed;
        float verticalMovement = movementY * playerMovementSpeed;

        playerRigidbody.velocity  = new Vector2(horizontalMovement, verticalMovement);
        playerRigidbody.position = new Vector2(
            Mathf.Clamp(playerRigidbody.position.x, boundary.Xmin, boundary.Xmax),
            Mathf.Clamp(playerRigidbody.position.y, boundary.Ymin, boundary.Ymax)
        );
           
        FindObjectOfType<PlayerAnimation>().SetDirection(playerRigidbody.velocity);
        
    }
}
