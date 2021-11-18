using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int rightPLayerScore = 0;
    public static int leftPlayerScore = 0;
    public static int gameScore = 5;                    //gamescore hold the value that the game will end at 
    public GUISkin layout;

    GameObject pongBall;

    // we call Start before the frames start
    void Start(){
        pongBall = GameObject.FindGameObjectWithTag("Ball");       //before the frame starts we assign the Ball object to game object pongBall
    }

    public static void ScoreBoard(string wallType){        // in the sidewalls function, when the ball touches side wall we call scoreboard,
        if (wallType == "RightWall"){      // if the wall type was the left persons wall then the opposig player gets a point
            rightPLayerScore++;
        }
        else{
            leftPlayerScore++;
        }
    }

    void OnGUI()       //onGui is a unity function that handles GUI events
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + rightPLayerScore);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + leftPlayerScore);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {     //here we set the gui buttom. If the restart button is pressed this is what we doo
            rightPLayerScore = 0;                   //reset players scores
            leftPlayerScore = 0;
            pongBall.SendMessage("GameRestart", 0.5f, SendMessageOptions.RequireReceiver);     //invoke the game restart funtion in ball controls
        }

        if (rightPLayerScore == gameScore){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "LEFT PLAYER WON");       //Rect is a structure in unity to define the x and y of a rectangle
            pongBall.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
        }
        else if (leftPlayerScore == gameScore){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "RIGHT PLAYER WON");
            pongBall.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
        }
    }

  
}
