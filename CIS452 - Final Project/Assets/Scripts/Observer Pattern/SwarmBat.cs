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

    private bool chasingPlayer;
    private GameObject player;

    public float minRange = 10f;
    private bool moveTowardsPlayerCoroutineRunning;

    private float tempMinRange;

    private float orgMovementSpeed;

    Color orgColor;

    public void UpdateData(bool inChaseMode, float movementSpeed)
    {
        chasingPlayer = inChaseMode;

        if (chasingPlayer && !moveTowardsPlayerCoroutineRunning)
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
        moveTowardsPlayerCoroutineRunning = false;
        swarmBatBehavior = FindObjectOfType<SwarmBehaviorData>();
        chasingPlayer = false;
        player = FindObjectOfType<Player_Movement>().gameObject;

        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;
        tempMinRange = minRange;
        orgColor = this.GetComponent<SpriteRenderer>().color;
        orgColor.a = .25f;
        this.GetComponent<SpriteRenderer>().color = orgColor;
        minRange = 10000000000000000000;
        Invoke("SpawnFix", 1);
    }

    private void SpawnFix()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().simulated = true;
        minRange = tempMinRange;

        orgColor.a = 1;
        this.GetComponent<SpriteRenderer>().color = orgColor;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDistance();
    }

    void OnEnable()
    {
        swarmBatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if (this.gameObject != null)
        {
            swarmBatBehavior.RegisterObserver(this);
        }
    }

    void OnDisable()
    {
        swarmBatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if (this.gameObject != null && swarmBatBehavior != null)
        {
            swarmBatBehavior.RemoveObserver(this);
        }
    }

    private void CheckPlayerDistance()
    {
        Vector3 playerPos = transform.position - player.transform.position;

        if (playerPos.x < minRange && playerPos.x > -minRange && playerPos.y < minRange && playerPos.y > -minRange)
        {
            swarmBatBehavior.chasingPlayer = true;
            swarmBatBehavior.NotifyObservers();
        }
        else if ((playerPos.x > minRange || playerPos.x < -minRange) && (playerPos.y > minRange && playerPos.y < -minRange))
        {
            swarmBatBehavior.chasingPlayer = false;
            swarmBatBehavior.NotifyObservers();
        }
    }

    private IEnumerator MoveTowardsPlayer(float movementSpeed)
    {
        moveTowardsPlayerCoroutineRunning = true;

        if (chasingPlayer)
        {
            if (gameObject != null && gameObject.activeSelf && player != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * 0.002f);
            }
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(MoveTowardsPlayer(movementSpeed));
    }

    private IEnumerator IdleMovement()
    {
        //Debug.Log("Bat idling! ");
        moveTowardsPlayerCoroutineRunning = false;

        yield return new WaitForSeconds(1f);

        if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement());
        }
    }

    public void DestroyObserver()
    {
        swarmBatBehavior.RemoveObserver(this);
        ObjectPooler.instance.ReturnObjectToPool("Bat", gameObject);
    }
}
