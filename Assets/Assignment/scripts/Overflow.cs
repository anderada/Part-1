using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overflow : MonoBehaviour
{
    public GameController controller;
    public Dropper dropper;

    //if a fruit collides with the top, reset the game
    void OnTriggerEnter2D(Collider2D other){
        Fruit otherFruit = other.gameObject.GetComponent<Fruit>();
        //check that the collision is with a fruit, and the fruit is not being held
        if(otherFruit && otherFruit.enabled){
            //reset the game
            controller.ResetGame();
            dropper.ResetCooldown();
        }
    }
}