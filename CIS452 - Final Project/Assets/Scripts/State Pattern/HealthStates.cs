using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthStates : MonoBehaviour
{
   [HideInInspector] public ParticleSystem movementParticles;

    private void Start()
    {
        movementParticles = this.GetComponent<ParticleSystem>();
    }

    public abstract void ChangeMovementParticle();
    public abstract void PlayerHealed();
}
