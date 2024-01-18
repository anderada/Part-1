using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject missile;
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(missile, spawnPoint);  
    }
}
