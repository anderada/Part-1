using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //size of the fruit
    public int size = 1;
    //the next fruit up in the size list
    public GameObject nextSize;
    //bool to stop both fruit from spawning the next fruit
    public bool theOtherFruitAlreadySpawnedOne = false;
    //keeps track of all the fruits
    GameController controller;

    void OnEnable(){
        controller = FindObjectOfType<GameController>();
    }

    void OnCollisionEnter2D(Collision2D other){
        //check if the collision is with a fruit
        Fruit otherFruit = other.gameObject.GetComponent<Fruit>();
        //check if the other fruit didn't spawn the next fruit already
        if(otherFruit && otherFruit.enabled && this.GetComponent<Fruit>().enabled && !theOtherFruitAlreadySpawnedOne){
            //check the fruit are the same size
            if(otherFruit.size == size){       
                //if there is a bigger fruit to spawn, spawn it at the midpoint between the colliding fruit 
                if(nextSize){
                    GameObject newFruit = Instantiate(nextSize, new Vector3(transform.position.x + (transform.position.x - other.gameObject.transform.position.x) /2f,
                                                                            transform.position.y + (transform.position.y - other.gameObject.transform.position.y) /2f, 0),
                                                                            Quaternion.identity);  
                    //enable the new fruit
                    newFruit.GetComponent<Fruit>().enabled = true;
                    //tell the other fruit not to spawn another fruit
                    otherFruit.theOtherFruitAlreadySpawnedOne = true;
                    //add the new fruit to the fruit list
                    controller.AddFruit(newFruit);
                }
                //destroy both colliding fruit
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
