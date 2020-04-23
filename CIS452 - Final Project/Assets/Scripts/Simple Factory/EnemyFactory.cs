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
        public enum EnemyTypes
        {
            Bat,
            Rat,
            Archer,
            Warrior,
            Wizard
        }

        public GameObject EnemyToSpawn(string enemyType)
        {
            GameObject enemyToSpawn = null;

            switch (enemyType)
            {
                case "Bat":
                    enemyToSpawn = enemies[(int)EnemyTypes.Bat];
                    break;
                case "Rat":
                    enemyToSpawn = enemies[(int)EnemyTypes.Rat];
                    break;
                case "Archer":
                    enemyToSpawn = enemies[(int)EnemyTypes.Archer];
                    break;
                case "Warrior":
                    enemyToSpawn = enemies[(int)EnemyTypes.Warrior];
                    break;
                case "Wizard":
                    enemyToSpawn = enemies[(int)EnemyTypes.Wizard];
                    break;
                default:
                    Debug.LogError("Enemy type not listed. Passed type: " + enemyType);
                    break;
            }

            return enemyToSpawn;
        }
    }
}