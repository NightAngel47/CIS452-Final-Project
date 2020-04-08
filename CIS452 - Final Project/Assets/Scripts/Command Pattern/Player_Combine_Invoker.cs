using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combine_Invoker : MonoBehaviour
{
    [HideInInspector]
    public static Stack<Tome> tomeStack = new Stack<Tome>();
    [HideInInspector]
    public static Tome currentTome;

    public static Tome offhandTome;

    public GameObject tomePickup;

    private CombineCommand combineCommand;

    private void Awake()
    {
        combineCommand = gameObject.AddComponent<CombineCommand>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentTome != null && offhandTome != null)
            {
                combineCommand.Execute();
            } else
            {
                Debug.LogWarning("You need two tomes to combine them!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (tomeStack.Peek() != null)
            {
                TossTome();
                combineCommand.Undo();
            } else
            {
                Debug.LogWarning("You can't split a tome that hasn't been combined!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentTome != null) currentTome.Print();
            if (offhandTome != null) offhandTome.Print();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (offhandTome != null)
            {
                Tome temp = currentTome;
                currentTome = offhandTome;
                offhandTome = temp;
                Debug.Log("Switch");
            } else
            {
                Debug.LogWarning("You only have one tome!");
            }
        }
    }

    private void TossTome()
    {
        GameObject discardTome = Instantiate(tomePickup, transform.position+new Vector3(0f,1f,0), Quaternion.identity);
        discardTome.GetComponent<TomePickup>().tome = offhandTome;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TomePickup>() != null)
        {
            if (currentTome == null)
            {
                currentTome = collision.gameObject.GetComponent<TomePickup>().tome;
                Destroy(collision.gameObject);
            } else
            {
                if (offhandTome != null) TossTome();
                offhandTome = collision.gameObject.GetComponent<TomePickup>().tome;
                Destroy(collision.gameObject);
            }
        }
    }
}
