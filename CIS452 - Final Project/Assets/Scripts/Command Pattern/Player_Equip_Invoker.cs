using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Equip_Invoker : MonoBehaviour
{
    [HideInInspector]
    public static Stack<Tome> tomeStack = new Stack<Tome>();
    [HideInInspector]

    public static Tome currentTome;

    public GameObject tomePickup;

    private EquipCommand equipCommand;

    private GameObject nearTome;

    private TomeManager tomeManager;
        
    private void Awake()
    {
        tomeManager = FindObjectOfType<TomeManager>();
        nearTome = null;
        equipCommand = gameObject.AddComponent<EquipCommand>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (nearTome != null)
            {
                if (currentTome != null)
                {
                    TossTome();
                }

                currentTome = nearTome.GetComponent<TomePickup>().tome;
                Destroy(nearTome);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipCommand.Execute();

            if (tomeManager)
            {
                tomeManager.Combine();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentTome != null)
            {
                TossTome();
            }

            equipCommand.Undo();

            if (tomeManager)
            {
                tomeManager.Combine();
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach(Tome t in tomeStack)
            {
                t.Print();
            }
        }
    }

    private void TossTome()
    {
        GameObject discardTome = Instantiate(tomePickup, transform.position+new Vector3(0f,1f,0), Quaternion.identity);
        discardTome.GetComponent<TomePickup>().tome = currentTome;
        currentTome = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TomePickup>() != null)
        {
            nearTome = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TomePickup>() != null)
        {
            nearTome = null;
        }
    }
}
