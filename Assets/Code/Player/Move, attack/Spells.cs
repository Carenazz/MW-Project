using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireSpell;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fireSpell, firePoint.position, firePoint.rotation);
    }
}
