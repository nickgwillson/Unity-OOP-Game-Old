using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D whoCollided)
    {
        if (whoCollided.name == "Ball")
        {
            string wallType = transform.name;           //here we attach the ontrigger2d transform function to grab the name of the wall that was hit
            GameManager.ScoreBoard(wallType);       // we notify the gamemanager scoreboard of the wall type that was given, depending on which wall was hit we will add point to respective player

            whoCollided.gameObject.SendMessage("GameRestart", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}

