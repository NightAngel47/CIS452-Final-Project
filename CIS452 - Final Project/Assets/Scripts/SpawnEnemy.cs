using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* William Nomikos, Steven Drovie
* SpawnEnemy.cs
* Final Project
* Activates enemies from the object pool at the spawner's position.
*/

public class SpawnEnemy : MonoBehaviour
{
    public string enemyType;
    private float timer;
    [SerializeField] private float spawnTime = 2f;
    private bool inRadius;

    private void Update()
    {
        if (inRadius)
        {
            timer += Time.deltaTime;
            if (timer > spawnTime)
            {
                ObjectPooler.instance.SpawnFromPool(enemyType, transform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRadius = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRadius = false;
        }
    }
}
