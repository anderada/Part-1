using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //list of fruits
    List<GameObject> fruits = new List<GameObject>();

    //adds a fruit to the list
    public void AddFruit(GameObject fruit){
        fruits.Add(fruit);
    }

    //deletes all the fruit in the list
    public void ResetGame(){
        foreach(GameObject fruit in fruits){
            Destroy(fruit);
        }
    }
}
