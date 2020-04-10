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
        //not needed but here just in case
    }

    public abstract void Attack();

    public abstract void Movement();
}
