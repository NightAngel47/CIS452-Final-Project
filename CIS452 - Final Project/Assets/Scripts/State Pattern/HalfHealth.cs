using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfHealth : HealthStates
{
    public override void ChangeMovementParticle()
    {
        movementParticles.startColor = Color.white;
        movementParticles.emissionRate = 5;
    }

    public override void PlayerHealed()
    {
        throw new System.NotImplementedException();
    }
}
