/*
 * Sydney Foe
 * Assignment 10
 * EnemyArcher
 * Sets up the archers behaviours. How it moves and attacks. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyTemplate
{
    public override void Attack()
    {
        if (seePlayer == true && distanceToPlayer > attackRangeMin)
        {
           // Debug.Log("Archer Shoots Arrow");
        }
    }

    public override void Movement()
    {
        //called randomly when not aggroed
        int rand = Random.Range(0, 20);

        if (rand <= 3)
        {
            //Debug.Log("Archer Moved");
        }
    }
}
