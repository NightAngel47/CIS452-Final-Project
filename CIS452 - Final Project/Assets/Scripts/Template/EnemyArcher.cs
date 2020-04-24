/*
 * Sydney Foe
 * Assignment 10
 * EnemyArcher
 * Sets up the archers behaviours. How it moves and attacks. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyTemplate
{
    public GameObject arc;
    public bool isMoving = false;
    public Vector3 endPos;
    public Vector3 startPos;
    public float speed = 1.0f;
    public bool moveRight;


    public override void Attack()
    {
        if (seePlayer == true) 
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            StartCoroutine("WaitTimeAttack");
        }

    }

    IEnumerator WaitTimeAttack()
    {
        yield return new WaitForSeconds(2f);
        methodCalled = false;
    }

    public override IEnumerator Movement()
    {
        //called randomly when not aggroed
        int rand = Random.Range(0, 10);

        if (rand <= 4)
        {

            float distance = Random.Range(moveMin, moveMax);

            moveRight = !moveRight;
            isMoving = true;
        }

        else
        {
            float randTime = Random.Range(1, 5);
            yield return new WaitForSeconds(randTime);
            methodCalled = false;
        }
    }

    public void Update()
    {
        EnemyActions();

        if (isMoving == true)
        {
            if (moveRight == true)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);

                if (transform.position.x >= endPos.x)
                {
                    isMoving = false;
                    StartCoroutine("WaitTime");
                }
            }

            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);

                if (transform.position.x <= startPos.x)
                {
                    isMoving = false;
                    StartCoroutine("WaitTime");
                }
            }
        }
    }

    IEnumerator WaitTime()
    {
        float randTime = Random.Range(1, 5);
        yield return new WaitForSeconds(randTime);
        methodCalled = false;
    }
}
