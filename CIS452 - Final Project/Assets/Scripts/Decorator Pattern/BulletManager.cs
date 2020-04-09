using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{ 
    public Tome thisTome;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            Shoot();
        }
    }
    private void SetTomes()
    {
       foreach(Tome t in Player_Equip_Invoker.tomeStack)
        {
            thisTome = Instantiate(t);
            t.SetBullet(thisTome);
        }
    }

    public void Shoot()
    {
        thisTome = null;

        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            t.SetBullet(null);
        }

        Debug.Log(Player_Equip_Invoker.tomeStack.Count);
        SetTomes();
        Debug.Log("Bullet Damage " + thisTome.GetDamage());
        Debug.Log("Fire Rate " + thisTome.GetRateOfFire());
    }
}
