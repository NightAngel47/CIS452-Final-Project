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
        swarmRatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if (this.gameObject != null)
        {
            swarmRatBehavior.RegisterObserver(this);
        }
    }

    void OnDisable()
    {
        swarmRatBehavior = FindObjectOfType<SwarmBehaviorData>();

        if (this.gameObject != null && swarmRatBehavior != null)
        {
            swarmRatBehavior.RemoveObserver(this);
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
            swarmRatBehavior.chasingPlayer = true;
            swarmRatBehavior.NotifyObservers();
        }
        else if (playerPos.x > minRange && playerPos.x < -minRange && playerPos.y > minRange && playerPos.y < -minRange)
        {
            swarmRatBehavior.chasingPlayer = false;
            swarmRatBehavior.NotifyObservers();
        }
    }

    private IEnumerator JumpTowardsPlayer(float movementSpeed, float jumpHeight)
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
            StartCoroutine(JumpTowardsPlayer(movementSpeed, jumpHeight));
        }
    }

    private IEnumerator IdleMovement(float jumpHeight)
    {
        //Debug.Log("Rat idling, and jumping occasionally at a height of " + jumpHeight + " because its a Rat! ");

        if (gameObject.activeSelf && gameObject != null && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, jumpHeight);
        }

        if (gameObject.activeSelf && gameObject != null && player != null)
        {
            float willJump = Random.Range(0, 100);

            if (willJump < 50)
            {
                transform.Translate(0, jumpHeight, 0);
            }
        }

        yield return new WaitForSeconds(1f);

        if (!chasingPlayer)
        {
            StartCoroutine(IdleMovement(jumpHeight));
        }
    }

    public void DestroyObserver()
    {
        swarmRatBehavior.RemoveObserver(this);
        ObjectPooler.instance.ReturnObjectToPool("Bat", gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Player it by Swarm Bat!");

    //        swarmRatBehavior.RemoveObserver(this);
    //        ObjectPooler.instance.ReturnObjectToPool("Rat", gameObject);
    //        //Destroy(this.gameObject);

    //        Debug.Log("The swarm bat also died!");
    //    }
    //}
}
