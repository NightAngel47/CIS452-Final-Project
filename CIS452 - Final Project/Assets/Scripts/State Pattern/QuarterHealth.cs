using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterHealth : HealthStates
{
    public override void ChangeMovementParticle()
    {
        movementParticles.startColor = Color.red;
        movementParticles.emissionRate = 50;
    }

    public override void PlayerHealed()
    {
        throw new System.NotImplementedException();
    }
}
