using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rigibody;    // rigidbosy2d is code given by unity that allows for physics to apply to our playermodel.

    public KeyCode Up = KeyCode.W;           //keycode.w is the w key on the keyboard
    public KeyCode Down = KeyCode.S;          //s
    public KeyCode Right = KeyCode.D;
    public KeyCode Left = KeyCode.A;
    public float playerSpeedy = 6.0f;      //here we can set players speed
    public float playerSpeedx = 2.0f;
    public float playerBoundy = 2.25f;            // we can set the boundry of the player in the game, shoudl be variable
    public float playerBoundx = 7.0f;

    // Start is called at the begining of the game, right before we start Updating our frames
    void Start(){
        rigibody = GetComponent< Rigidbody2D >();         
    }

    // Update is called once per frame, this is similar to an observer pattern 
    void Update()             
    {
  //the observer pattern if like a constatnt while statement used when displaying 2d visual games.
        var playerPosition = transform.position;        //transfrom.position is a rigibody function whcih is the players positon on the screen

        if (playerPosition.y > playerBoundy) {               //checking where the position is in comparison to the boundry we have set
            playerPosition.y = playerBoundy;                   //if the positon of the player is over the boundry set the postion of the player to the boundry
        }
        else if (playerPosition.y < -playerBoundy){        //if the players positon is below the boundry, the bottom of the screen, set the postion of the player to the border 
            playerPosition.y = -playerBoundy;
        }
        if (playerPosition.x > playerBoundx){               
            playerPosition.x = playerBoundx;                   
        }
        else if (playerPosition.x < -playerBoundx){        
            playerPosition.x = -playerBoundx;
        }
       
        transform.position = playerPosition;            //updating the players postion to stay inside boundry

        var playervelocity = rigibody.velocity;       //rigibody velocity is the velocity of the player in real time in the game
                                                      // get the current key pressed during the game
        if (Input.GetKey(Up)) {                      //input.getkey checks what button the user presses on the keyboard
            playervelocity.y = playerSpeedy;  //if key is 'up' or W add player speed to the velocity
        }
        else if (Input.GetKey(Down)){
            playervelocity.y = -playerSpeedy;    //-playerspeed applied to velocity makes the player move down
        }
        else if (Input.GetKey(Right)){
            playervelocity.x = playerSpeedx;
        }
        else if (Input.GetKey(Left)){
            playervelocity.x = -playerSpeedx;
        }
        else{
            playervelocity.y = 0;        //else if no keys are being pressed velocity is zero
            playervelocity.x = 0;
        }

        rigibody.velocity = playervelocity;                     //so in the above if statements we set player velocity to the correct 

        


    }
}
