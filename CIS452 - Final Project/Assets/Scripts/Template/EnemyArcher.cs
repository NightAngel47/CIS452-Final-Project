using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyTemplate
{
    public void Update()
    {
        AgroPlayer();
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
        Debug.Log("Archer Moved");
    }
}
