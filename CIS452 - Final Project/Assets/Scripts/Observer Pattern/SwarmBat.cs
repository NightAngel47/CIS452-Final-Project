/*
* William Nomikos
* SwarmBat.cs
* Final Project
* Concrete observer that handles behavior for the Swarm Bat enemy based on the subject.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBat : MonoBehaviour, IObserver
{
    private SwarmBehaviorData swarmBatBehavior;

    private SpriteRenderer rend;
    private Color defaultColor;
    private bool chasingPlayer;

    public void UpdateData(bool inChaseMode, float movementSpeed, float jumpHeight, Color color, float damageRate, float damageStrength)
    {
        defaultColor = color;
        chasingPlayer = inChaseMode;

        if (chasingPlayer)
        {
            StartCoroutine(MoveTowardsPlayer(movementSpeed));
        }
        else if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        swarmBatBehavior = FindObjectOfType<SwarmBehaviorData>();
        rend = GetComponent<SpriteRenderer>();
        swarmBatBehavior.RegisterObserver(this);
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

    private IEnumerator MoveTowardsPlayer(float movementSpeed)
    {
        Debug.Log("Bat moving towards player at the speed of : " + movementSpeed + "! ");
        yield return new WaitForSeconds(1f);

        if (chasingPlayer)
        {
            StartCoroutine(MoveTowardsPlayer(movementSpeed));
        }
    }

    private IEnumerator IdleMovement()
    {
        Debug.Log("Bat idling! ");
        yield return new WaitForSeconds(1f);

        if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player it by Swarm Bat!");

            swarmBatBehavior.RemoveObserver(this);
            Destroy(this.gameObject);

            Debug.Log("The swarm bat also died!");
        }
    }

    private void OnDestroy()
    {
        swarmBatBehavior.RemoveObserver(this);
    }

}
