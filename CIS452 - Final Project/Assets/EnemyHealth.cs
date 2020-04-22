using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();

        SetHealthBar();
        orgColor = sr.color;

        rb = this.GetComponent<Rigidbody2D>();
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
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(FindObjectOfType<TomeManager>().GetDamage());
            Destroy(collision.gameObject);
            FindKnockDirection(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(FindObjectOfType<TomeManager>().GetDamage());
            Destroy(collision.gameObject);
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
