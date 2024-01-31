using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int size = 1;
    public GameObject nextSize;
    public bool theOtherFruitAlreadySpawnedOne = false;

    void OnCollisionEnter2D(Collision2D other){
        Fruit otherFruit = other.gameObject.GetComponent<Fruit>();
        if(otherFruit && !theOtherFruitAlreadySpawnedOne){
            if(otherFruit.size == size){        
                if(nextSize){
                    Instantiate(nextSize, new Vector3(transform.position.x + (transform.position.x - other.gameObject.transform.position.x) /2f,
                                transform.position.y + (transform.position.y - other.gameObject.transform.position.y) /2f, 0),
                                Quaternion.identity);  
                    otherFruit.theOtherFruitAlreadySpawnedOne = true;
                }
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
