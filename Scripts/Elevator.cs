using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool StartElevator = false;
    public Rigidbody2D rb;
    public bool FallingDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartElevator == true)
        {
            rb.velocity = new Vector2(0f, 100f * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collisioninfo)
    {
        if (collisioninfo.tag == "Player") 
        {
            StartElevator = true;
        }
        if (collisioninfo.tag == "StopPoint")
        {
            FallingDown = true;
            StartElevator = false;

            rb.velocity = new Vector2(0f, -100f * Time.deltaTime);
        }
        if (collisioninfo.tag == "Ground")
        {
            if(FallingDown == true)
            {
                rb.velocity = new Vector2(0f, 0f);
                FallingDown = false;
            }       
        }
    }
}
