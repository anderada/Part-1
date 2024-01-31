using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<GameObject> fruits = new List<GameObject>();

    public void AddFruit(GameObject fruit){
        fruits.Add(fruit);
    }

    public void ResetGame(){
        foreach(GameObject fruit in fruits){
            Destroy(fruit);
        }
    }
}
