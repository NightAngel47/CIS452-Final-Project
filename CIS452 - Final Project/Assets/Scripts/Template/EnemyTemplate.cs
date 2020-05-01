/*
 * Sydney Foe
 * Final Project
 * EnemyTemplate
 * Sets up the enemy template. Handles player agro, death. Creates attack and movement methods for each enemy to create themselves
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : MonoBehaviour
{
    public bool seePlayer = false;
    public float distanceToPlayer = 0;
    public float attackRangeMin;
    public float attackRangeMax;
    public float castRadius;
    public LayerMask playerLayer;
    //public float health;

    public float moveMin;
    public float moveMax;

    public bool methodCalled = false;

    public GameObject projectilePrefab;

    Color orgColor;

    protected bool canAttack = false;

    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;
        orgColor = this.GetComponent<SpriteRenderer>().color;
        orgColor.a = .25f;
        this.GetComponent<SpriteRenderer>().color = orgColor;
        canAttack = false;
        Invoke("SpawnFix", 1);
    }

    private void OnEnable()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;
        orgColor = this.GetComponent<SpriteRenderer>().color;
        orgColor.a = .25f;
        this.GetComponent<SpriteRenderer>().color = orgColor;
        canAttack = false;
        Invoke("SpawnFix", 1);
      
    }

    private void SpawnFix()
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().simulated = true;

        orgColor.a = 1;
        this.GetComponent<SpriteRenderer>().color = orgColor;
        canAttack = true;
    }

    public void AgroPlayer()
    {
        RaycastHit2D playerCheck;
        Vector3 p1 = transform.position;

        playerCheck = Physics2D.CircleCast(transform.position, castRadius, Vector2.zero, 0.3f, playerLayer);

        if(playerCheck.transform != null)
        {
            seePlayer = true;
            //distanceToPlayer = hit.distance;
        }

        else
        {
            seePlayer = false;
        }
    }

    public void Death()
    { 
        Destroy(gameObject);
    }

    public void EnemyActions()
    {
        AgroPlayer();

        if (canAttack)
        {
            if (seePlayer == false && methodCalled == false)
            {
                methodCalled = true;
                StartCoroutine("Movement");
            }

            if (seePlayer == true && methodCalled == false)
            {
                methodCalled = true;
                Attack();
            }
        }
       


    }

    public abstract void Attack();

    public abstract IEnumerator Movement();
}
