using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Levi Schoof
* Dead.cs
* Final Project
* Implaments the HealthStates abstract classs
* The health stats that is used when the player is dead
*/
public class Dead : HealthStates
{
    private bool dead;
    private void Start()
    {
        dead = false;
    }
    public override void ChangeMovementParticle()
    {
        ParticleSystem.MainModule settings = movementParticles.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(Color.black);
        ParticleSystem.EmissionModule em = movementParticles.emission;
        em.rateOverTime = 5; 
    }

    public override void PlayerHealed()
    {
        Debug.Log("Should Not Be able to heal you are dead");
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

        ChangeMovementParticle();

        if (!dead)
        {
            dead = true;
            FindObjectOfType<GameManager>().PlayerDied();
        }
       

    }
}
