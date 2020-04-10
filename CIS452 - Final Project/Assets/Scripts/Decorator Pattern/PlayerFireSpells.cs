using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireSpells : MonoBehaviour
{
    BulletManager bulletManager;
    public GameObject spellPrefab;
    public GameObject currentSpell;

    private float currentTime = 0;

    Vector3 mousePos;
    Vector3 mouseDir;
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        FireSpell();
    }

    private void FireSpell()
    {
        if (bulletManager.thisTome)
        {
            if (currentTime > bulletManager.GetFireRate() && Input.GetMouseButton(0))
            {
                Debug.Log("FireRate " + bulletManager.GetFireRate());
                Debug.Log("Damage " + bulletManager.GetDamage());
                currentTime = 0;
                currentSpell = Instantiate(spellPrefab, this.transform.position, Quaternion.identity);
                currentSpell.GetComponent<Rigidbody2D>().AddForce(mouseDir * bulletManager.GetSpeed() * Time.deltaTime);
            }
        }
       
    }
}
