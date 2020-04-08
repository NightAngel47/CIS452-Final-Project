using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTome", menuName = "Tome")]
public class Tome : ScriptableObject
{
    public new string name;
    public Sprite uiImage;
    public int damage;
    public float rateOfFire;
    public GameObject bullet;

    public void Print()
    {
        Debug.Log(name + ", " + damage / rateOfFire + " DPS.");
    }
}
