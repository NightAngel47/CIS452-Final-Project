using System.Collections.Generic;
using UnityEngine;

/*
 * Steven Drovie
 * EnemyFactory.cs
 * CIS452 - Final Project
 * Handles simple factory pattern for enemy spawning
 */

namespace Simple_Factory
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemies = new List<GameObject>();

        public GameObject EnemyToSpawn(string enemyType)
        {
            GameObject enemyToSpawn = null;

            switch (enemyType)
            {
                case "Bat":
                    enemyToSpawn = enemies[0];
                    break;
                case "Rat":
                    enemyToSpawn = enemies[1];
                    break;
                case "Archer":
                    enemyToSpawn = enemies[2];
                    break;
                case "Warrior":
                    enemyToSpawn = enemies[3];
                    break;
                case "Wizard":
                    enemyToSpawn = enemies[4];
                    break;
                default:
                    Debug.LogError("Enemy type not listed. Passed type: " + enemyType);
                    break;
            }

            return enemyToSpawn;
        }
    }
}