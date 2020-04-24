/*
* Levi Schoof
* FullHealth.cs
* Final Project
* Implaments the HealthStates abstract classs
* The health stats that is used when the player is at Full Health
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullHealth : HealthStates
{
    public override void ChangeMovementParticle()
    {
        ParticleSystem.MainModule settings = movementParticles.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(Color.green);
        ParticleSystem.EmissionModule em = movementParticles.emission;
        em.rateOverTime = 5;
    }

    public override void TakeDamage()
    {
        if (flashImage)
        {
            StopCoroutine(FadeImage());
            tempColor = flashImage.GetComponent<Image>().color;
            tempColor = Color.white;
            tempColor.a = .5f;
            flashImage.GetComponent<Image>().color = tempColor;
            StartCoroutine(FadeImage());
        }

        ChangeMovementParticle();
    }
}
