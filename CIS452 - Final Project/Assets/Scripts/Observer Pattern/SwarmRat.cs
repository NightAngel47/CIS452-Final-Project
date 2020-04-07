﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmRat : MonoBehaviour, IObserver
{
    private SwarmBehaviorData swarmRatBehavior;

    private SpriteRenderer rend;
    private Color defaultColor;
    private bool chasingPlayer;

    public void UpdateData(bool inChaseMode, float movementSpeed, float jumpHeight, Color color, float damageRate, float damageStrength)
    {
        defaultColor = color;

        chasingPlayer = inChaseMode;

        if (chasingPlayer)
        {
            StartCoroutine(JumpTowardsPlayer(movementSpeed, jumpHeight));
        }
        else if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement(jumpHeight));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        swarmRatBehavior = FindObjectOfType<SwarmBehaviorData>();
        rend = GetComponent<SpriteRenderer>();
        swarmRatBehavior.RegisterObserver(this);
        chasingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor(defaultColor);
    }

    private void ChangeColor(Color defaultColor)
    {
        rend.material.SetColor("_Color", defaultColor);
    }

    private IEnumerator JumpTowardsPlayer(float movementSpeed, float jumpHeight)
    {
        Debug.Log("Rat jumping at player at the speed of : " + movementSpeed + " with a height of " + jumpHeight + "! ");
        yield return new WaitForSeconds(1f);

        if (chasingPlayer)
        {
            StartCoroutine(JumpTowardsPlayer(movementSpeed, jumpHeight));
        }
    }

    private IEnumerator IdleMovement(float jumpHeight)
    {
        Debug.Log("Rat idling, and jumping occasionally at a height of " + jumpHeight + " because its a Rat! ");
        yield return new WaitForSeconds(1f);

        if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement(jumpHeight));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player it by Swarm Bat!");
        }

        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Swarm bat defeated!");

            swarmRatBehavior.RemoveObserver(this);
            Destroy(this.gameObject);
        }
    }
}