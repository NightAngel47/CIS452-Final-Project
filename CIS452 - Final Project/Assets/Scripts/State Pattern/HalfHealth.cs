using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalfHealth : HealthStates
{
    public override void ChangeMovementParticle()
    {
        ParticleSystem.MainModule settings = movementParticles.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(Color.white);
        ParticleSystem.EmissionModule em = movementParticles.emission;
        em.rateOverTime = 5;
    }

    public override void TakeDamage()
    {
        if (flashImage)
        {
            StopCoroutine(FadeImage());
            tempColor = flashImage.GetComponent<Image>().color;
            tempColor = Color.red;
            tempColor.a = .5f;
            flashImage.GetComponent<Image>().color = tempColor;
            StartCoroutine(FadeImage());
        }

        ChangeMovementParticle();
    }
}
