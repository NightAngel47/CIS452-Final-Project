/*
* William Nomikos
* SwarmRat.cs
* Final Project
* Concrete observer that handles behavior for the Swarm Rat enemy based on the subject.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmRat : MonoBehaviour, IObserver
{
    private SwarmBehaviorData swarmRatBehavior;

    private bool chasingPlayer;
    private GameObject player;

    public float minRange = 10f;
    private float tempMinRange;

    Color orgColor;

    public void UpdateData(bool inChaseMode, float movementSpeed)
    {
        chasingPlayer = inChaseMode;

        if (chasingPlayer)
        {
            StartCoroutine(JumpTowardsPlayer(movementSpeed));
        }
        else if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement(movementSpeed));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        swarmRatBehavior = FindObjectOfType<SwarmBehaviorData>();
        swarmRatBehavior.RegisterObserver(this);
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
        swarmRatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if (this.gameObject != null)
        {
            swarmRatBehavior.RegisterObserver(this);
        }

        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;
        tempMinRange = minRange;
        orgColor = this.GetComponent<SpriteRenderer>().color;
        orgColor.a = .25f;
        this.GetComponent<SpriteRenderer>().color = orgColor;
        minRange = 10000000000000000000;
        Invoke("SpawnFix", 1);
    }

    void OnDisable()
    {
        swarmRatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if (this.gameObject != null && swarmRatBehavior != null)
        {
            swarmRatBehavior.RemoveObserver(this);
        }
    }

    private void CheckPlayerDistance()
    {
        Vector3 playerPos = transform.position - player.transform.position;

        if (playerPos.x < minRange && playerPos.x > -minRange && playerPos.y < minRange && playerPos.y > -minRange)
        {
            swarmRatBehavior.chasingPlayer = true;
            swarmRatBehavior.NotifyObservers();
        }
        else if (playerPos.x > minRange && playerPos.x < -minRange && playerPos.y > minRange && playerPos.y < -minRange)
        {
            swarmRatBehavior.chasingPlayer = false;
            swarmRatBehavior.NotifyObservers();
        }
    }

    private IEnumerator JumpTowardsPlayer(float movementSpeed)
    {
        if (gameObject != null && gameObject.activeSelf && player != null)
        {
            Vector2 newPos = player.transform.position;
            newPos.y = this.transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, newPos, movementSpeed * 0.002f);
        }

        yield return new WaitForSeconds(1f);

        if (chasingPlayer)
        {
            StartCoroutine(JumpTowardsPlayer(movementSpeed));
        }
    }

    private IEnumerator IdleMovement(float moveSpeed)
    {
        if (gameObject.activeSelf && gameObject != null && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
        }

        if (gameObject.activeSelf && gameObject != null && player != null)
        {
            float willJump = Random.Range(0, 100);

            if (willJump < 50)
            {
                transform.Translate(0, moveSpeed, 0);
            }
        }

        yield return new WaitForSeconds(1f);

        if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement(moveSpeed));
        }
    }

    public void DestroyObserver()
    {
        swarmRatBehavior.RemoveObserver(this);
        ObjectPooler.instance.ReturnObjectToPool("Bat", gameObject);
    }
}
