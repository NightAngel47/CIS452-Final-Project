using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBat : MonoBehaviour, IObserver
{
    private SwarmBatBehaviorData swarmBatBehavior;

    private float moveSpeed = 0f;
    private float jumpPower = 0f;
    private Color defaultColor;
    private float damageSpeed = 0f;
    private float damagePower = 0f;
    private SpriteRenderer rend;

    public void UpdateData(bool inChaseMode, float movementSpeed, float jumpHeight, Color color, float damageRate, float damageStrength)
    {
        moveSpeed = movementSpeed;
        jumpPower = jumpHeight;
        defaultColor = color;
        damageSpeed = damageRate;
        damagePower = damageStrength;

        if (inChaseMode)
        {
            StartCoroutine(MoveTowardsPlayer(movementSpeed));
        }
        else if (!inChaseMode)
        {
            StartCoroutine(IdleMovement());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        swarmBatBehavior = FindObjectOfType<SwarmBatBehaviorData>();
        rend = GetComponent<SpriteRenderer>();
        swarmBatBehavior.RegisterObserver(this);
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
        Debug.Log("Bat moving towards player! ");
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator IdleMovement()
    {
        Debug.Log("Bat idling! ");
        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player it by Swarm Bat!");
        }

        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Swarm bat defeated!");

            swarmBatBehavior.RemoveObserver(this);
            Destroy(this.gameObject);
        }
    }

}
