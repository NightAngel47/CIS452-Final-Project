/*
* William Nomikos
* Temp.cs
* Final Project
* Handles main menu button navigation. Temporary until we have an implemented main menu.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip auroraBorealis;
    public ParticleSystem buttonParticles;
    GameObject buttonParticlesObj;
    public float yParticleModifier = 0f;

    public void ButtonParticles()
    {
        AudioSource.clip = auroraBorealis;
        AudioSource.Play();

        Vector3 doughnutParticleLocation = new Vector3(0, 0, 1);
        buttonParticlesObj = Instantiate(buttonParticles.gameObject, doughnutParticleLocation, Quaternion.Euler(-90f, 0f, 0f));
        buttonParticles.Play();

        Destroy(buttonParticlesObj, 20f);
    }
}
