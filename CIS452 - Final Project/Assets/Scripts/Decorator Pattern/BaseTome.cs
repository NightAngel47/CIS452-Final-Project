using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTome : ScriptableObject
{
    public int damage;
    public float rateOfFire;
    public float speed;

    #region Get Stats
    public abstract int GetDamage();

    public abstract float GetRateOfFire();

    public abstract float GetSpeed();

    #endregion
}
