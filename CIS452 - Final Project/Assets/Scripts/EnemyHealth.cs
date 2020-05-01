using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Levi Schoof
* EnemyHealth.cs
* Final Project
* Handels the enemy's health and taking damage.
*/

public class EnemyHealth : MonoBehaviour
{
    public Slider healthBar;
    public int healthMax;
    private int currentHealth;

    private SpriteRenderer sr;
    private Color orgColor;

    private Vector2 knockBarkDirection;
    private float knockBackAmmount = 50;

    private Rigidbody2D rb;

    public bool knockback = true;

    private AudioSource enemyDamageSource;
    public AudioClip batDamage;
    public AudioClip ratDamage;
    public AudioClip archerDamage;
    public AudioClip warriorDamage;
    public AudioClip wizardDamage;


    // Start is called before the first frame update
    void Start()
    {
        enemyDamageSource = GameObject.Find("EnemyDamage").GetComponent<AudioSource>();
        sr = this.GetComponent<SpriteRenderer>();

        SetHealthBar();
        orgColor = sr.color;
        orgColor.a = 1;

        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        SetHealthBar();
    }

    private void SetHealthBar()
    {
        healthBar.maxValue = healthMax;
        currentHealth = healthMax;
        healthBar.value = currentHealth;
        healthBar.gameObject.SetActive(false);
    }

    private void TakeDamage(int damage)
    {
        if(enemyDamageSource == null)
        {
            enemyDamageSource = GameObject.Find("EnemyDamage").GetComponent<AudioSource>();
        }

        if (gameObject.tag == "Bat")
        {
            enemyDamageSource.clip = batDamage;
            enemyDamageSource.Play();
        }
        else if (gameObject.tag == "Rat")
        {
            enemyDamageSource.clip = ratDamage;
            enemyDamageSource.Play();
        }
        else if (gameObject.tag == "Archer")
        {
            enemyDamageSource.clip = archerDamage;
            enemyDamageSource.Play();
        }
        else if (gameObject.tag == "Warrior")
        {
            enemyDamageSource.clip = warriorDamage;
            enemyDamageSource.Play();
        }
        else if (gameObject.tag == "Wizard")
        {
            enemyDamageSource.clip = wizardDamage;
            enemyDamageSource.Play();
        }

       
        StopCoroutine(DamageFlash());
        currentHealth -= damage;
    
        healthBar.gameObject.SetActive(true);
        healthBar.value = currentHealth;
        StartCoroutine(DamageFlash());

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    IEnumerator DamageFlash()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(.25f);
        sr.color = orgColor;
        yield return new WaitForSeconds(1);
        healthBar.gameObject.SetActive(false);
    }

    private void Death()
    {
        sr.color = orgColor;
        if(this.gameObject.tag == "Bat")
        {
            this.gameObject.GetComponent<SwarmBat>().DestroyObserver();
        }
        else if(this.gameObject.tag == "Rat")
        {
            this.gameObject.GetComponent<SwarmRat>().DestroyObserver();
        }
        else
        {
            ObjectPooler.instance.ReturnObjectToPool(this.gameObject.tag, this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(FindObjectOfType<TomeManager>().GetDamage());
            FindKnockDirection(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(FindObjectOfType<TomeManager>().GetDamage());
            FindKnockDirection(collision.gameObject);
        }
    }

    private void FindKnockDirection(GameObject hit)
    {
        if (hit.transform.position.x > this.transform.position.x)
        {
            knockBarkDirection = Vector3.left;
        }

        else
        {
            knockBarkDirection = Vector3.right;
        }

        if (hit.transform.position.y > this.transform.position.y)
        {
            knockBarkDirection += Vector2.down;
          
        }

        else
        {
            knockBarkDirection += Vector2.up;
        }

        rb.AddForce(knockBarkDirection * knockBackAmmount);

    }
}
