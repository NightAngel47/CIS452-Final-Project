using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Connor Wolf
 * TomePickup.cs
 * CIS452 - Final Project
 * Handles picking up tomes
 */

public class TomePickup : MonoBehaviour
{
    public GameObject statsPanel;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI FireRateText;
    public TextMeshProUGUI SpeedText;
    public Tome tome;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = 
            (Vector2.up * 3 + 
            Vector2.right);

        OpenPanel(false);
    }

    public void OpenPanel(bool open)
    {
        statsPanel.SetActive(open);
        if (tome)
        {
            damageText.text = "Damage: +" + tome.damage;
            FireRateText.text = "Fire Rate: /" + tome.rateOfFire;
            SpeedText.text = "Spell Speed: +" + tome.speed;
        }
    }


}
