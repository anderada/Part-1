using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime );
    }
}
