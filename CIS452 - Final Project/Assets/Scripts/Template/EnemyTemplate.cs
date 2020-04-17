/*
 * Sydney Foe
 * Assignment 10
 * EnemyTemplate
 * Sets up the enemy template. Handles player agro, death. Creates attack and movement methods for each enemy to create themselves
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
    public bool seePlayer = false;
    public float distanceToPlayer = 0;
    public float attackRangeMin;
    public float attackRangeMax;
    public float castRadius;
    public LayerMask playerLayer;
    //public float health;

    public int enemyType;

    public void AgroPlayer()
    {
        RaycastHit2D playerCheck;
        Vector3 p1 = transform.position;

        playerCheck = Physics2D.CircleCast(transform.position, castRadius, Vector2.zero, 0.3f, playerLayer);

        if(playerCheck.transform != null)
        {
            seePlayer = true;
            //distanceToPlayer = hit.distance;
        }

        else
        {
            seePlayer = false;
        }
    }

    public void Death()
    { 
        //called when player attacks enemy\
        //since no attack is fully in enemy will not die
        Destroy(gameObject);
    }

    public void TemplateMethod()
    {
        AgroPlayer();

        if (seePlayer == false)
        {
            if(enemyType == 1)
            {
                gameObject.transform.position = Vector3.zero;
            }
            Movement();
        }

        if (seePlayer == true)
        {
            Attack();
        }  

        
    }

    public abstract void Attack();

    public abstract void Movement();
}
