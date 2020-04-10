using System.Collections.Generic;
using UnityEngine;

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
            
        public GameObject EnemyToSpawn(EnemyTypes enemyType)
        {
            GameObject enemyToSpawn = null;

            switch (enemyType)
            {
                case EnemyTypes.Bat: enemyToSpawn = enemies[(int) EnemyTypes.Bat];
                    break;
                case EnemyTypes.Rat: enemyToSpawn = enemies[(int) EnemyTypes.Rat];
                    break;
                case EnemyTypes.Archer: enemyToSpawn = enemies[(int) EnemyTypes.Archer];
                    break;
                case EnemyTypes.Warrior: enemyToSpawn = enemies[(int) EnemyTypes.Warrior];
                    break;
                case EnemyTypes.Wizard: enemyToSpawn = enemies[(int) EnemyTypes.Wizard];
                    break;
                default:
                    Debug.LogError("Enemy type not listed. Passed type: " + enemyType);
                    break;
            }

            return enemyToSpawn;
        }
    }
}