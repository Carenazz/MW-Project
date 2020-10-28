using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireSpell;

    public int cost;
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
                Shoot();
                cost = 25;
                timer = 4f;
            }
        }
        else
            timer -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(fireSpell, firePoint.position, firePoint.rotation);

        mana.ManaUsed(cost);
    }
}
