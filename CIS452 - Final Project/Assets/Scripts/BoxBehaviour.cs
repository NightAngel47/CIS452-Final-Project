﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
