using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simple_Factory;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler instance;

    private EnemyFactory enemyFactory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        enemyFactory = GetComponent<EnemyFactory>();
        FillPools();
    }

    private void FillPools()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject thisObject = Instantiate(enemyFactory.EnemyToSpawn(pool.tag), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                thisObject.SetActive(false);
                objectPool.Enqueue(thisObject);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void ReturnObjectToPool(string tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        poolDictionary[tag].Enqueue(objectToReturn);
    }
}

