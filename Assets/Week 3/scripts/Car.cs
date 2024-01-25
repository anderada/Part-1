using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float steeringSpeed = 10f;
    public float forwardSpeed = 20f;
    public float maxSpeed = 50f;
    public Rigidbody2D rigidbody;

    float steering = 0;
    float acceleration = 0;

    // Update is called once per frame
    void Update()
    {
        steering = Input.GetAxis("Horizontal");
        acceleration = Input.GetAxis("Vertical");
    }

    void FixedUpdate(){
        rigidbody.AddTorque(steeringSpeed * steering * Time.deltaTime);
        Vector2 force = transform.up * forwardSpeed * acceleration * Time.deltaTime;
        Debug.Log(acceleration);
        if(rigidbody.velocity.magnitude < maxSpeed){
            rigidbody.AddForce(force);
        }
    }
}
