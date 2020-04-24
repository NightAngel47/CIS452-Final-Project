using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Connor Wolf, Levi Schoof
* BoxBehaviour.cs
* Final Project
* Handles the functionality of boxes.
*/

public class BoxBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
