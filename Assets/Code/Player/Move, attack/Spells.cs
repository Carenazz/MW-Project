using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireSpell;

    [SerializeField]
    private int cost;

    Mana mana;

    private void Start()
    {
        mana = GetComponent<Mana>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Shoot();
            cost = 25;
        }
    }

    void Shoot()
    {
        Instantiate(fireSpell, firePoint.position, firePoint.rotation);

        mana.ManaUsed(cost);
    }
}
