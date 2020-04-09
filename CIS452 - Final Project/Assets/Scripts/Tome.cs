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
    public Tome bullet;

    public void Print()
    {
        Debug.Log(name + ", " + damage / rateOfFire + " DPS.");
    }

    public void SetBullet(Tome newBullet)
    {
        bullet = newBullet;
    }

    public int GetDamage()
    {
        if (bullet)
        {
            return bullet.GetDamage() + damage;
        }

        return damage;
    
    }

    public float GetRateOfFire()
    {
        if (bullet)
        {
            return bullet.GetRateOfFire() + damage;
        }

        return rateOfFire;
    }
}
