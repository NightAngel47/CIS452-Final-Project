using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Levi Schoof
 * TempSpellScript.cs
 * CIS452 - Final Project
 * Handles basic spell
 */

public class TempSpellScripts : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DeathTime());
    }
    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
