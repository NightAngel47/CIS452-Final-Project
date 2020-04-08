using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : EnemyTemplate
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
        if(seePlayer == true && distanceToPlayer > attackRangeMin)
        {
            Debug.Log("Wizard Cast Spell");
        }
    }

    public override void Movement()
    {
        Debug.Log("Wizard Teleported");
    }
}
