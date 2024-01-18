using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (door.activeInHierarchy == true) door.SetActive(false);
        else door.SetActive(true); 
    }
}
