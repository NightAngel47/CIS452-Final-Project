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
        //called randomly when not aggroed
        int rand = Random.Range(0, 20);

        if (rand <= 3)
        {
            Debug.Log("Wizard Teleported");
        }
    }
}
