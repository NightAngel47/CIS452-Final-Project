using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Levi Schoof
 * ConcreteTome.cs
 * CIS452 - Final Project
 * Concrete class for tomes
 */

public class ConcreteTome : BaseTome
{
    public override int GetDamage()
    {
        return 0;
    }

    public override float GetRateOfFire()
    {
        return 1;
    }

    public override float GetSpeed()
    {
        return 0;
    }
}
