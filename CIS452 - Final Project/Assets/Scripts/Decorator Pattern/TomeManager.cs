﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * Levi Schoof
 * TomeManager.cs
 * CIS452 - Final Project
 * Manages tomes
 */

public class TomeManager : MonoBehaviour
{
    public BaseTome thisTome;
    public GameObject spellVisual;

    public TextMeshProUGUI damage;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI spellSpeed;

    private void Start()
    {
        thisTome = null;
        thisTome = ScriptableObject.CreateInstance<ConcreteTome>();
        SetUI();
    }

    public void Combine()
    {
        thisTome = null;
        thisTome = ScriptableObject.CreateInstance<ConcreteTome>();
        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            t.SetTome(thisTome);
        }

        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            t.SetTome(thisTome);
            thisTome = Instantiate(t);
        }

        SetUI();
    }

    public int GetDamage() { return thisTome.GetDamage(); }

    public float GetFireRate() { return thisTome.GetRateOfFire(); }

    public float GetSpeed() { return thisTome.GetSpeed(); }

    private void SetUI()
    {
        damage.text = "Current Damage: " + thisTome.GetDamage();
        fireRate.text = "Seconds Between Shots: " + thisTome.GetRateOfFire();
        spellSpeed.text = "Spell Speed: " + thisTome.GetSpeed();
    }
}
