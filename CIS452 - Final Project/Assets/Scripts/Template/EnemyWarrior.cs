using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : EnemyTemplate
{
    public void Update()
    {
        AgroPlayer();

        if (seePlayer == false)
        {
            Movement();
        }

        if (seePlayer == true)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        if (seePlayer == true && (distanceToPlayer > attackRangeMin && distanceToPlayer < attackRangeMax))
        {
            Debug.Log("Warrior Attacks");
        }
    }

    public override void Movement()
    {
        //called randomly when not aggroed
        Debug.Log("Warrior Moved Agressively");
    }
}
