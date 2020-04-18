using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        currentHealth = maxHealth;

        currentHealthState = fullHealthState;

        deadHealthState = this.GetComponent<Dead>();
        fullHealthState = this.GetComponent<FullHealth>();
        halfHealthState = this.GetComponent<HalfHealth>();
        quarterHealthState = this.GetComponent<QuarterHealth>();

        ChangeState(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        if(damage < 0)
        {
            currentHealthState.PlayerHealed();
        }

        currentHealth -= damage;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if(currentHealth <= 0)
        {
            PlayerDied();
        }

        healthBar.value = currentHealth;

        ChangeState(damage);
    }

    private void ChangeState(int dam)
    {
        if(currentHealth > maxHealth / 2) {currentHealthState = fullHealthState;}
        else if(currentHealth <= maxHealth /2 && currentHealth > maxHealth / 4){ currentHealthState = halfHealthState; }
        else if(currentHealth > 0 && currentHealth <= maxHealth / 4) { currentHealthState = quarterHealthState; }
        else { currentHealthState = deadHealthState; }

        currentHealthState.ChangeMovementParticle();
        if(dam > 0)
        {
            currentHealthState.TakeDamage();
        }

        else if (dam < 0)
        {
            currentHealthState.PlayerHealed();
        }
     
        

    }

    private void PlayerDied()
    {
        Debug.Log("Oh Shucks You Died");
    }
}
