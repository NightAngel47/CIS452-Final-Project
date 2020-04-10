using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyTemplate
{
    public void Update()
    {
        AgroPlayer();

        if(seePlayer == false)
        {
            Movement();
        }

        if(seePlayer == true)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        if (seePlayer == true && distanceToPlayer > attackRangeMin)
        {
            Debug.Log("Archer Shoots Arrow");
        }
    }

    public override void Movement()
    {
        //called randomly when not aggroed
        Debug.Log("Archer Moved");
    }
}
