using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireSpell;
    private float timer = 0f;

    Mana mana;

    private void Start()
    {
        mana = GetComponent<Mana>();
    }

    void Update()
    {
        if (timer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (mana.mana >= 25)
                {
                    Shoot();
                    mana.ManaUsed(25);
                    timer = 3f;
                }
            }
        }
        else
            timer -= Time.deltaTime;
    }

    // Mål: Sørg for animations til firespell + at den ikke bliver ved med at travelle efter impact.
    void Shoot()
    {
        Instantiate(fireSpell, firePoint.position, firePoint.rotation);
    }
}