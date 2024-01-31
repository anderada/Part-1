using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overflow : MonoBehaviour
{
    public GameController controller;
    public Dropper dropper;

    void OnTriggerEnter2D(Collider2D other){
        controller.ResetGame();
        dropper.ResetCooldown();
    }
}