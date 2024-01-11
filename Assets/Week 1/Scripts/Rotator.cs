using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 360; 

    void Update()
    {
        transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
    }
}
