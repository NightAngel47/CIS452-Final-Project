using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TomeManager : MonoBehaviour
{
    public BaseTome thisTome;
    public GameObject spellVisual;

    public TextMeshProUGUI damage;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI spellSpeed;

    private void Start()
    {
        thisTome = null;
        thisTome = ScriptableObject.CreateInstance<ConcreteTome>();
        SetUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
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

        SetUI();
    }

    public int GetDamage() { return thisTome.GetDamage(); }

    public float GetFireRate() { return thisTome.GetRateOfFire(); }

    public float GetSpeed() { return thisTome.GetSpeed(); }

    private void SetUI()
    {
        damage.text = "Current Damage: " + thisTome.GetDamage();
        fireRate.text = "Fire Rate " + thisTome.GetRateOfFire();
        spellSpeed.text = "Spell Speed: " + thisTome.GetSpeed();
    }
}
