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
    public float speed;

    [HideInInspector] public Tome bullet;

    public void SetBullet(Tome newBullet)
    {
        bullet = newBullet;
    }

    public void Print()
    {
        Debug.Log(name + ", " + damage / rateOfFire + " DPS.");
    }

    #region Get Stats
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
            return bullet.GetRateOfFire() / rateOfFire;
        }

        return rateOfFire;
    }

    public float GetSpeed()
    {
        if (bullet)
        {
            return bullet.GetRateOfFire() + damage;
        }

        return rateOfFire;
    }

    #endregion
}
