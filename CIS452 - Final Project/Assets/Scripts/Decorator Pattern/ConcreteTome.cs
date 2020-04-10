using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
