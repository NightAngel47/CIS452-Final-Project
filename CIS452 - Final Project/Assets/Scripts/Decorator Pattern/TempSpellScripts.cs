using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpellScripts : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DeathTime());
    }
    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
