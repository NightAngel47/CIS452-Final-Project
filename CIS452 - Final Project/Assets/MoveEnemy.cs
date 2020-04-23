using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public string enemyType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ObjectPooler.instance.SpawnFromPool(enemyType, transform.position, Quaternion.identity);
        }
    }
}
