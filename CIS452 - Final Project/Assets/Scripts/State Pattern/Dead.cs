﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : HealthStates
{
    public override void ChangeMovementParticle()
    {
        movementParticles.startColor = Color.black;
        movementParticles.emissionRate = 50;
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
            tempColor = Color.black;
            tempColor.a = 1f;
            flashImage.GetComponent<Image>().color = tempColor;
            StartCoroutine(FadeImage());
        }

    }
}
