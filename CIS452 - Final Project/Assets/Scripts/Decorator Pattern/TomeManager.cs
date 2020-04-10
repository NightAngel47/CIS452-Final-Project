using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeManager : MonoBehaviour
{
    public BaseTome thisTome;
    public GameObject spellVisual;

    private void Start()
    {
        thisTome = null;
        thisTome = ScriptableObject.CreateInstance<ConcreteTome>();
    }
    public void Combine()
    {
        thisTome = null;
        thisTome = ScriptableObject.CreateInstance<ConcreteTome>();
        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            t.SetTome(thisTome);
        }

        foreach (Tome t in Player_Equip_Invoker.tomeStack)
        {
            thisTome = Instantiate(t);
            t.SetTome(thisTome);
        }
    }

    public int GetDamage() { return thisTome.GetDamage(); }

    public float GetFireRate() { return thisTome.GetRateOfFire(); }

    public float GetSpeed() { return thisTome.GetSpeed(); }
}
