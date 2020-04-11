using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTome", menuName = "Tome")]
public class Tome : BaseTome
{
    public new string name;
    public Sprite uiImage;

    [HideInInspector] public BaseTome tome;

    public void SetTome(BaseTome newTome)
    {
        tome = newTome;
    }

    public void Print()
    {
        Debug.Log(name + ", " + damage / rateOfFire + " DPS.");
    }

    #region Get Stats
    public override int GetDamage()
    {
        return tome.GetDamage() + damage;
    }

    public override float GetRateOfFire()
    {
        return tome.GetRateOfFire() / rateOfFire;
    }

    public override float GetSpeed()
    {
        return tome.GetSpeed() + damage;
    }

    #endregion
}
