/*
 * Sydney Foe
 * Assignment 10
 * EnemyWarrior
 * Sets up the warriors behaviours. How it moves and attacks. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : EnemyTemplate
{
    public GameObject war;
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
            StartCoroutine("WaitTime");
        }

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        methodCalled = false;
    }

    public override IEnumerator Movement()
    {

        if (isMoving == false)
        {
            moveRight = !moveRight;
            isMoving = true;

            yield return new WaitForSeconds(.1f);
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

                if(transform.position.x >= endPos.x)
                {
                    isMoving = false;
                    methodCalled = false;
                }
            }

            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);

                if (transform.position.x <= startPos.x)
                {
                    isMoving = false;
                    methodCalled = false;
                }
            }
        }
    }

}
