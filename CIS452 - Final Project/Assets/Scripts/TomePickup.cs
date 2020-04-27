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
            if (tome.damage > 0)
            {
                damageText.text = "Damage: <b><color=green>+" + tome.damage + "</b></color>";
            }

            else if (tome.damage < 0)
            {
                damageText.text = "Damage: <b><color=red>-" + tome.damage + "</b></color>";
            }

            else
            {
                damageText.text = "Damage: No Change";
            }

            if (tome.rateOfFire > 1)
            {
                FireRateText.text = "Fire Rate: <b><color=green>/" + tome.rateOfFire + "</b></color>";
            }

            else if (tome.rateOfFire == 1)
            {
                FireRateText.text = "Fire Rate: No Change";
            }

            else
            {
                FireRateText.text = "Fire Rate: <b><color=red>/" + tome.rateOfFire + "</b></color>";
            }

            if (tome.speed > 0)
            {
                SpeedText.text = "Spell Speed: <b><color=green>+" + tome.speed + "</b></color>";
            }

            else if (tome.speed < 0)
            {
                SpeedText.text = "Spell Speed: <b><color=red>-" + tome.speed + "</b></color>";
            }

            else
            {
                SpeedText.text = "Spell Speed: No Change";
            }
            
        }
    }


}
