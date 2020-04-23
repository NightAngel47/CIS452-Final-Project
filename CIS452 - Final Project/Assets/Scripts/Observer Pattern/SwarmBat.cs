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
    private GameObject player;

    public float minRange = 10f;

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
        //swarmBatBehavior.RegisterObserver(this);
        chasingPlayer = false;
        player = FindObjectOfType<Player_Movement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor(defaultColor);
        CheckPlayerDistance();
    }

    void OnEnable()
    {
        swarmBatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if(this.gameObject != null)
        {
            swarmBatBehavior.RegisterObserver(this);
        }
    }

    void OnDisable()
    {
        swarmBatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if(this.gameObject != null)
        {
            swarmBatBehavior.RemoveObserver(this);
        }
    }

    private void ChangeColor(Color defaultColor)
    {
        rend.material.SetColor("_Color", defaultColor);
    }

    private void CheckPlayerDistance()
    {
        Vector3 playerPos = transform.position - player.transform.position;

        if (playerPos.x < minRange && playerPos.x > -minRange && playerPos.y < minRange && playerPos.y > -minRange)
        {
            swarmBatBehavior.chasingPlayer = true;
            swarmBatBehavior.NotifyObservers();
        }
        else if (playerPos.x > minRange && playerPos.x < -minRange && playerPos.y > minRange && playerPos.y < -minRange)
        {
            swarmBatBehavior.chasingPlayer = false;
            swarmBatBehavior.NotifyObservers();
        }
    }

    private IEnumerator MoveTowardsPlayer(float movementSpeed)
    {
        Debug.Log("Bat moving towards player at the speed of : " + movementSpeed + "! ");

        //transform.Translate(2 * Time.deltaTime * movementSpeed, 2 * Time.deltaTime * movementSpeed, 0);
        
        if(gameObject != null && gameObject.activeSelf && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * 0.002f);
        }

        yield return new WaitForSeconds(1f);

        if (chasingPlayer)
        {
            StartCoroutine(MoveTowardsPlayer(movementSpeed));
        }

        yield return new WaitForEndOfFrame();
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
            ObjectPooler.instance.ReturnObjectToPool("Bat", gameObject);

            //swarmBatBehavior.RemoveObserver(this);
            //Destroy(this.gameObject);

            Debug.Log("The swarm bat also died!");
        }
    }
}
