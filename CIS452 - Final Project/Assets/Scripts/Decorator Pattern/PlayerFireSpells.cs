using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Levi Schoof
 * PlayerFireSpells.cs
 * CIS452 - Final Project
 * Handles firing spells on player input
 */

public class PlayerFireSpells : MonoBehaviour
{
    TomeManager tomeManager;
    public GameObject spellPrefab;
    public GameObject currentSpell;

    private float currentTime = 0;

    Vector3 mousePos;
    Vector3 mouseDir;
    // Start is called before the first frame update
    void Start()
    {
        tomeManager = FindObjectOfType<TomeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        FireSpell();
    }

    private void FireSpell()
    {

        if (currentTime > tomeManager.GetFireRate() && Input.GetMouseButton(0))
        {
            Debug.Log("FireRate " + tomeManager.GetFireRate());
            Debug.Log("Damage " + tomeManager.GetDamage());
            currentTime = 0;
            currentSpell = Instantiate(spellPrefab, this.transform.position, Quaternion.identity);
            currentSpell.GetComponent<Rigidbody2D>().AddForce(mouseDir * tomeManager.GetSpeed() * Time.deltaTime);
        }


    }
}
