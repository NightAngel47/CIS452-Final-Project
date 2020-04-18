using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
}
