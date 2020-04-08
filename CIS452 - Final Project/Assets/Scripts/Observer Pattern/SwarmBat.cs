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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player was hit by Swarm Bat!");
            swarmBatBehavior.RemoveObserver(this);
            Destroy(this.gameObject);

            Debug.Log("The swarm bat also died!");

        }

        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Swarm bat defeated!");

            swarmBatBehavior.RemoveObserver(this);
            Destroy(this.gameObject);
        }
    }

}
