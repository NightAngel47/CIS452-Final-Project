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

    public float moveMin;
    public float moveMax;

    public bool methodCalled = false;

    public GameObject projectilePrefab;

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
        Destroy(gameObject);
    }

    public void EnemyActions()
    {
        AgroPlayer();

        if (seePlayer == false && methodCalled == false)
        {
            methodCalled = true;
            StartCoroutine("Movement");
        }

        if (seePlayer == true && methodCalled == false)
        {
            methodCalled = true;
            Attack();
        }


    }

    public abstract void Attack();

    public abstract IEnumerator Movement();
}
