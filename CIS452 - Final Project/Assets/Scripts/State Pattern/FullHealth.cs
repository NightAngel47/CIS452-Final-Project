using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealth : HealthStates
{
    public override void ChangeMovementParticle()
    {
        movementParticles.startColor = Color.green;
        movementParticles.emissionRate = 5;
    }

    public override void PlayerHealed()
    {
        throw new System.NotImplementedException();
    }
}
