/*
 * Sydney Foe
 * Assignment 10
 * EnemyWizard
 * Sets up the wizards behaviours. How it moves and attacks. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : EnemyTemplate
{

    public void Start()
    {
        enemyType = 1;  
    }

    public override void Attack()
    {
        
        if(seePlayer == true && distanceToPlayer > attackRangeMin)
        {
            Debug.Log("Wizard Cast Spell");
        }
    }

    public override void Movement()
    {
        //called randomly when not aggroed
        int rand = Random.Range(0, 100);
        

        if (rand <= 50)
        {
            Debug.Log("Wizard Teleported");
            float distance = Random.Range(.25f, 1.25f);
            int side = Random.Range(0, 2);
            Debug.Log(distance);
            if (side == 0) //move right
            {
                Debug.Log("here");
                gameObject.transform.position = new Vector3(distance, 0, 0);
                //gameObject.transform.position = Vector3.zero;
            }

            if (side == 1) //move left
            {
                Debug.Log("here2");
                gameObject.transform.position = new Vector3(distance, 0, 0);
            }
        }
    }
}
