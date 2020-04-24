using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Levi Schoof
* QuarterHealth.cs
* Final Project
* Implaments the HealthStates abstract classs
* The health stats that is used when the player is at a Quarter Health
*/

public class QuarterHealth : HealthStates
{
    public override void ChangeMovementParticle()
    {
        ParticleSystem.MainModule settings = movementParticles.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(Color.red);
        ParticleSystem.EmissionModule em = movementParticles.emission;
        em.rateOverTime = 20;
    }

    public override void TakeDamage()
    {
        if (flashImage)
        {
            StopCoroutine(FadeImage());
            tempColor = flashImage.GetComponent<Image>().color;
            tempColor = Color.red;
            tempColor.a = 1f;
            flashImage.GetComponent<Image>().color = tempColor;
            StartCoroutine(FadeImage());
        }

        ChangeMovementParticle();
    }
}
