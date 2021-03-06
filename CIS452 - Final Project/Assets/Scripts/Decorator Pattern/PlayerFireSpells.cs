﻿/*
 * Levi Schoof
 * PlayerFireSpells.cs
 * CIS452 - Final Project
 * Handles firing spells on player input
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFireSpells : MonoBehaviour
{
    TomeManager tomeManager;
    public GameObject spellPrefab;
    public GameObject currentSpell;

    private float currentTime = 0;

    Vector3 mousePos;
    Vector3 mouseDir;

    public AudioSource soundEffectSource;
    public AudioClip shootingSound;

    // Start is called before the first frame update
    void Start()
    {
        tomeManager = FindObjectOfType<TomeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        FireSpell();
    }

    private void FireSpell()
    {

        if (currentTime > tomeManager.GetFireRate() && Input.GetMouseButton(0))
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDir = mousePos - gameObject.transform.position;
            mouseDir.z = 0.0f;
            mouseDir = mouseDir.normalized;

            soundEffectSource.clip = shootingSound;
            soundEffectSource.Play();

            currentTime = 0;
            currentSpell = Instantiate(spellPrefab, this.transform.position, Quaternion.identity);
            currentSpell.GetComponent<Rigidbody2D>().velocity = (mouseDir * tomeManager.GetSpeed());
        }


    }
}
