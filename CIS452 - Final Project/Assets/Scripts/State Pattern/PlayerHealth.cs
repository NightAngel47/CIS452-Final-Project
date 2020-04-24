﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Levi Schoof
* PlayerHealth.cs
* Final Project
* Handels the player's health and taking damage.
* Also handles/uses the health states
*/

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public Slider healthBar;

    private int currentHealth;

    HealthStates currentHealthState;
    Dead deadHealthState;
    FullHealth fullHealthState;
    HalfHealth halfHealthState;
    QuarterHealth quarterHealthState;

    public float maxInvinceTime = .5f;
    private bool isInvince;

    private float currentCount = 0;
    private bool damageTaken = false;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        damageTaken = false;
        
        //Convert invincibility time from frames to seconds by dividing it by the time step
        maxInvinceTime /= 0.02f;

        currentCount = maxInvinceTime;

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        currentHealth = maxHealth;

     
        //Player states
        deadHealthState = this.GetComponent<Dead>();
        fullHealthState = this.GetComponent<FullHealth>();
        halfHealthState = this.GetComponent<HalfHealth>();
        quarterHealthState = this.GetComponent<QuarterHealth>();

        currentHealthState = fullHealthState;

        currentHealthState.ChangeMovementParticle();

        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    TakeDamage(1);
        //}

        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    TakeDamage(-1);
        //}
    }

    private void FixedUpdate()
    {
        //Invincibility timer that runs once damage is taken
        if(damageTaken)
        {
            if(currentCount > 0)
            {
                currentCount--;
            }
            else if(currentCount <= 0)
            {
                damageTaken = false;
                currentCount = maxInvinceTime;
            }
        }
    }

    /// <summary>
    /// Changes the players health by the value passed in. If positive value, player takes damage.
    /// If negative value, player heals. Damage will only be taken if the player has no invincibility
    /// frames left.
    /// </summary>
    /// <param name="damage"></param>
    private void TakeDamage(int damage)
    {
        if(!damageTaken && damage > 0)
        {
            currentHealth -= damage;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            else if (currentHealth <= 0)
            {
                currentHealthState = deadHealthState;
            }

            healthBar.value = currentHealth;

            damageTaken = true;

            ChangeState(damage);
        }
        else if(damage < 0)
        {
            currentHealthState.PlayerHealed();
        }
    }

    /// <summary>
    /// Changes the player's state based on how much health they have.
    /// </summary>
    /// <param name="dam"></param>
    private void ChangeState(int dam)
    {
        if (currentHealth > maxHealth / 2) { currentHealthState = fullHealthState; }
        else if (currentHealth <= maxHealth / 2 && currentHealth > maxHealth / 4) { currentHealthState = halfHealthState; }
        else if (currentHealth > 0 && currentHealth <= maxHealth / 4) { currentHealthState = quarterHealthState; }

        if (dam > 0)
        {
            currentHealthState.TakeDamage();
        }

        else if (dam < 0)
        {
            currentHealthState.PlayerHealed();
        }
    }

    #region DamageColliders

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Bat") || collision.gameObject.CompareTag("Rat") || collision.gameObject.CompareTag("Warrior"))
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            TakeDamage(1);
        }
    }

    #endregion
}