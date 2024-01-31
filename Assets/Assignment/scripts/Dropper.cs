using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody2D rigidbody;
    public Transform spawnpoint;
    public GameObject cherry;
    public GameObject strawberry;
    public GameObject grape;
    public GameObject dekopon;
    public GameObject orange;
    public GameController controller;
    GameObject heldFruit;
    int spawnCooldown = 0;


    // Update is called once per frame
    void Update()
    {
        //get input and calculate force
        Vector2 force = transform.right * Input.GetAxis("Horizontal") * speed;
        //add force
        rigidbody.AddForce(force);

        if(heldFruit){
            //move fruit to new location
            heldFruit.transform.Translate(transform.position.x - heldFruit.transform.position.x, 0, 0);

            //drop fruit on spacebar press
            if(Input.GetKeyDown("space")){
                //set fruit gravity to 1 to drop
                heldFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
                //set heldfruit reference to null so it doesn't follow the dropper's X position anymore
                heldFruit = null;
                //set the spawn cooldown to give the fruit time to fall away
                spawnCooldown = 30;
            }
        }
    }

    void FixedUpdate(){
        if(spawnCooldown == 0){
            //instantiate new fruit
            heldFruit = Instantiate(cherry, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, 0), Quaternion.identity);
            controller.AddFruit(heldFruit);
            //set fruit gravity to 0 to keep held
            heldFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        spawnCooldown--;
    }

    public void ResetCooldown(){
        spawnCooldown = 0;
    }

    
}
