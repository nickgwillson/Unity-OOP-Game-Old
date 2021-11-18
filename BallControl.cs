using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void ballDirection(){    //start ball is where the ball will go when you start the game, it should be random left or right
        float ballDirection = Random.Range(0, 2);   //randm number from 0, 1

        if (ballDirection < 1){     //if number is 1 ball goes to the right
            rigidbody.AddForce(new Vector2(20, -15) );          //addforce is a unity function, which acts like a force exertoning on a rigibody object
        }
        else{
            rigidbody.AddForce( new Vector2(-20, -15) );    //Vector 2 is a unity function representing 2d postions/vectors
        }
    }

    // Start is called at the begining of the game, right before we start Updating our frames
    void Start(){
        rigidbody = GetComponent< Rigidbody2D >();     //grabbing the rigidbody2d unity function, setting it to variable rigidbody
        Invoke("ballDirection", 2);                  //when we call our ball direction functin

    }
      
    void BallReset(){                           //we call this function when we restart the game or the ball hits the wall
        rigidbody.velocity = Vector2.zero;                  //we set velocity and postion back to beginning 
        transform.position = Vector2.zero;
    }

    void GameRestart() {       //this function is called in gamemanager and sidewalls
        BallReset();        //when we restart the game we want to reset the ball
        Invoke("ballDirection", 1);
    }

    void OnCollisionEnter2D(Collision2D ballCollision){

        if (ballCollision.collider.CompareTag("Player")){    //IF THE BALL COLLIDES WITH A PLAYER
            Vector2 ballVelocity;     //have ball velocity become a vector variable

            ballVelocity.x = rigidbody.velocity.x;   // set the ball velocity equal to the rigidbody velocity that wew defined at the top 
           // ballVelocity.y = (rigidbody.velocity.y / 2) + (ballCollision.collider.attachedRigidbody.velocity.y / 3);    //set vertical ball velocity to 
            ballVelocity.y = rigidbody.velocity.y;    //set vertical ball velocity to 

            rigidbody.velocity = ballVelocity;  //set velocity to respective velocity set in beginning
        }

 
    }

}
