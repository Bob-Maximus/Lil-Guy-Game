using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void Death()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bad")
        {
            Death();
        }
    }
}
