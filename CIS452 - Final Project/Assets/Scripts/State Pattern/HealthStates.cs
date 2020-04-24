/*
* Levi Schoof
* HealthStates.cs
* Final Project
* The abstract class for the players different health states.
* Changes screen flash and particle effects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class HealthStates : MonoBehaviour
{

   [HideInInspector] public ParticleSystem movementParticles;
   [HideInInspector] public GameObject flashImage;
   [HideInInspector] public Color tempColor;

    private void Start()
    {
        movementParticles = this.GetComponent<ParticleSystem>();
        flashImage = GameObject.FindGameObjectWithTag("Flash");
    }

    public abstract void ChangeMovementParticle();
    public virtual void PlayerHealed()
    {
        ParticleSystem.MainModule settings = movementParticles.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(Color.green);
        ParticleSystem.EmissionModule em = movementParticles.emission;
        em.rateOverTime = 100;

        StartCoroutine(HealChange());
    }
    public abstract void TakeDamage();

    public IEnumerator FadeImage()
    {
        tempColor = flashImage.GetComponent<Image>().color;
        while(tempColor.a > 0)
        {
            tempColor.a -= .1f;
            flashImage.GetComponent<Image>().color = tempColor;
            yield return new WaitForSeconds(.05f);
        }
    }

    IEnumerator HealChange()
    {
        yield return new WaitForSeconds(1);
        ChangeMovementParticle();
    }
}
