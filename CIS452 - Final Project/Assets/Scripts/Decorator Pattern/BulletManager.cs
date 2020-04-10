using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Tome thisTome;
    public GameObject spellVisual;

    public void Combine()
    {
        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            t.SetBullet(null);
        }

        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            thisTome = Instantiate(t);
            t.SetBullet(thisTome);
        }
    }

    public int GetDamage() { return thisTome.GetDamage(); }

    public float GetFireRate() { return thisTome.GetRateOfFire(); }

    public float GetSpeed() { return thisTome.GetSpeed(); }
}
