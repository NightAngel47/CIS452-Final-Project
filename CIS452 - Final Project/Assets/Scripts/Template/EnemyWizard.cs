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
    public GameObject wiz;
    

    public void Start()
    {
        enemyType = 1;  
    }

    public void Update()
    {
        //StartCoroutine("EnemyActions");
        EnemyActions();
    }

    public override void Attack()
    {
        
        if(seePlayer == true && distanceToPlayer > attackRangeMin)
        {
            Debug.Log("Wizard Cast Spell");
        }
        methodCalled = false;
    }

    public override IEnumerator Movement()
    {
        //called randomly when not aggroed
        int rand = Random.Range(0, 10);

        if (rand <= 4)
        {
            Debug.Log("Wizard Teleported");
            float distance = Random.Range(moveMin, moveMax);
            int side = Random.Range(0, 2);
            if (side == 0) //move right
            {
                wiz.transform.position = new Vector3(distance, wiz.transform.position.y, 0);
                //gameObject.transform.position = Vector3.zero;
            }

            if (side == 1) //move left
            {
                wiz.transform.position = new Vector3(distance, wiz.transform.position.y, 0);
            }
        }

        float randTime = Random.Range(1, 5);
        yield return new WaitForSeconds(randTime);
        methodCalled = false;
    }
}
