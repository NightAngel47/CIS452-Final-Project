using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : EnemyTemplate
{
    public void Update()
    {
        AgroPlayer();
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
        Debug.Log("Warrior Moved Agressively");
    }
}
