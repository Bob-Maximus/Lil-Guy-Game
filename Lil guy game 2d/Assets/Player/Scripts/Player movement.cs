using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlayerData data;

    //what we will set the velocity to
    private float realSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        //getting the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input();
    }

    //input function cuz its bad practice to put it all into the update loop
    public void input()
    {
        //we will take the speed from our data and lerp the realspeed to it so that its smoother
        if (Input.GetKey(KeyCode.A))
        {
            realSpeed = Mathf.Lerp(realSpeed, -data.speed, Time.deltaTime * data.acceleration);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            realSpeed = Mathf.Lerp(realSpeed, data.speed, Time.deltaTime * data.acceleration);
        } 
        else
        {
            realSpeed = Mathf.Lerp(realSpeed, 0, Time.deltaTime * data.acceleration);
        }

        //setting the velocity to our realspeed
        rb.velocity = new Vector2(realSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            //checking if the player can fly (player dosent need to be touching ground to jump) of if they are touching the ground
            if (data.canFly || isGrounded())
            {
                rb.AddForce(transform.up * data.jumpHeight * 10);
            }
        }
    }

    //bool for if the player is grounded
    public bool isGrounded()
    {
        //sends a laser downwards and checks if it touches the groud
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, 1.1f);

        //if the ray touches the ground, the player is touching the ground
        return hit.collider != null && hit.collider.tag != "Player";
        //                              
        //                             / \ this is here to make sure that the ray ignored that players body
        //                              |
    }
}
