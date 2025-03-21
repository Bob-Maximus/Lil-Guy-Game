using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //what will tell the player they're dead
    GameObject deathMessage;
    private void Start()
    {
        //getting the deathmessage
        deathMessage = GameObject.Find("Death Message");

        //making it invisible to not have it bkock the view
        deathMessage.SetActive(false);
    }

    public void Death()
    {
        //showing the deathmessage and pausing time 
        deathMessage.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //if the player ctouches something bad, die
        if (col.gameObject.tag == "bad")
        {
            Death();
        }
    }
}
