using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (spriteRenderer != null) { 
            spriteRenderer.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject + " is in the triger");
        if (spriteRenderer != null) spriteRenderer.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (spriteRenderer != null) spriteRenderer.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
