using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
    public bool seePlayer = false;
    public float distanceToPlayer = 0;
    public float attackRangeMin;
    public float attackRangeMax;
    //public float health;

    public void AgroPlayer()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position;

        if (Physics.SphereCast(p1, 10 / 2, transform.forward, out hit, 10))
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                seePlayer = true;
                distanceToPlayer = hit.distance;
            }
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

    public void TemplateMethod()
    {
        //not needed but here just in case
    }

    public abstract void Attack();

    public abstract void Movement();
}
