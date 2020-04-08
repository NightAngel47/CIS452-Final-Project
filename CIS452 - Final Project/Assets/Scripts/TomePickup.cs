﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomePickup : MonoBehaviour
{
    public Tome tome;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = 
            (Vector2.up * 3 + 
            Vector2.right);
    }
}
