using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody2D rigidbody;
    //where the fruit spawns
    public Transform spawnpoint;
    //fruit prefabs
    public GameObject cherry;
    public GameObject strawberry;
    public GameObject grape;
    public GameObject dekopon;
    public GameObject orange;
    //game controller keeps track of and deletes fruit
    public GameController controller;
    //currently held fruit
    GameObject heldFruit;
    //cooldown timer to give time for the dropped fruit to get out of the way
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
                //enable fruit script so it can combine with other fruit
                heldFruit.GetComponent<Fruit>().enabled = true;
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
            GameObject toSpawn;

            //select random fruit to drop
            switch((int)Random.Range(0, 5)){
                case 0:
                    toSpawn = cherry;
                    break;
                case 1:
                    toSpawn = strawberry;
                    break;
                case 2:
                    toSpawn = grape;
                    break;
                case 3:
                    toSpawn = dekopon;
                    break;
                case 4:
                    toSpawn = orange;
                    break;
                default:
                    toSpawn = cherry;
                    break;
            }
            //instantiate fruit
            heldFruit = Instantiate(toSpawn, new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, 0), Quaternion.identity);
            //add the fruit to the fruit list
            controller.AddFruit(heldFruit);
            //set fruit gravity to 0 to keep held
            heldFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
            //disable fruit script so it doesn't combine with other fruit while held
            heldFruit.GetComponent<Fruit>().enabled = false;
        }
        //update cooldown timer
        spawnCooldown--;
    }

    //reset cooldown timer on game reset
    public void ResetCooldown(){
        spawnCooldown = 0;
    }

    
}
